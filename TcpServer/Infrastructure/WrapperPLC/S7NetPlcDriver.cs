using Packet;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TVM_WMS.SERVER
{
    public class S7NetPlcDriver : ISyncPlcDriver
    {
        private Plc client;

        public S7NetPlcDriver(CpuType cpu, string ip, short rack, short slot)
        {
            client = new Plc(cpu, ip, rack, slot);
        }

        private ConnectionStates _connectionState;
        public ConnectionStates ConnectionState
        {
            get { return _connectionState; }
            private set { _connectionState = value; }
        }

        public void Connect()
        {
            ConnectionState = ConnectionStates.Connecting;
            var error = client.Open();

            ConnectionState = (error != ErrorCode.NoError) ? ConnectionStates.Offline : ConnectionStates.Online;
        }

        public bool IsConnected()
        {
            bool result = false;

            result = client.IsConnected;
            _connectionState = (result) ? ConnectionStates.Online : ConnectionStates.Offline;

            return result;
        }

        public bool IsAvailable()
        {
            return client.IsAvailable;
        }

        public void DisconnectVegetablePLC()
        {
            ConnectionState = ConnectionStates.Vegetable;
            client.Close();
        }

        public void Disconnect()
        {
            ConnectionState = ConnectionStates.Offline;
            client.Close();
        }

        public void ReadAllVar(PlcListenVar item, int db)
        {
            if (this.ConnectionState != ConnectionStates.Online)
            {
                throw new Exception("Can't read, the client is disconnected.");
            }

            client.ReadClass(item, db);

            //if (client is ErrorCode && (ErrorCode)result != ErrorCode.NoError)
            //{
            //    throw new Exception(((ErrorCode)result).ToString());
            //}

        }

        public object ReadVar(string dbVar)
        {
            object result = null;

            if (this.ConnectionState == ConnectionStates.Online)
            {
                result = client.Read(dbVar);

                if (result is ErrorCode && (ErrorCode)result != ErrorCode.NoError)
                {
                    result = null;
                    //throw new Exception(((ErrorCode)result).ToString() + "\n");
                }
            }
            else
            {
                result = null;
                //throw new Exception("Can't read, the client is " + this.ConnectionState + ".");
            }
            return result;
        }

        public byte[] ReadMultipleBytes(int numBytes, int db, int startByteAdr = 0)
        {
            List<byte> resultBytes = new List<byte>();
            int index = startByteAdr;
            while (numBytes > 0)
            {
                var maxToRead = (int)Math.Min(numBytes, 200);
                byte[] bytes = client.ReadBytes(DataType.DataBlock, db, index, (int)maxToRead);
                if (bytes == null)
                    return new List<byte>().ToArray<byte>();
                resultBytes.AddRange(bytes);
                numBytes -= maxToRead;
                index += maxToRead;
            }
            return resultBytes.ToArray<byte>();
        }
        

        public void WriteItem(string varAlias, object varValue)
        {

            try
            {
                if (this.ConnectionState != ConnectionStates.Online)
                {
                    throw new Exception("Can't write, the client is disconnected.");
                }

                object value = varValue;

                if (value is double)
                {
                    var bytes = S7.Net.Types.Double.ToByteArray((double)value);
                    value = S7.Net.Types.DWord.FromByteArray(bytes);
                }
                else if (value is bool)
                {
                    value = (bool)value ? 1 : 0;
                }

                var result = client.Write(varAlias, value);

                if ((ErrorCode)result != ErrorCode.NoError)
                {
                    throw new Exception(((ErrorCode)result).ToString() + "\n" + "Tag: " + varAlias);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи!\n" + ex.Message, "Запись значения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }

       

        public void WriteEmptyTextItem(DataItemsQueryDTO tag, int currentDB, int replicate)
        {
            if (this.ConnectionState != ConnectionStates.Online)
            {
                throw new Exception("Can't write, the client is disconnected.");
            }

            int offset = Int32.Parse(tag.Offset.Substring(0, tag.Offset.IndexOf('.')));

            var result = client.WriteBytes(DataType.DataBlock, currentDB, offset + 2, S7.Net.Types.String.ToByteArray(new String('\0', replicate)));

            if ((ErrorCode)result != ErrorCode.NoError)
            {
                throw new Exception(((ErrorCode)result).ToString() + "\n" + "Tag: " + tag.Name);
            }
        }
    }
}
