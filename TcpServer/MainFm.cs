using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WatsonTcp;
using Packet;
using S7.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace TVM_WMS.SERVER
{
    public partial class MainFm : DevExpress.XtraEditors.XtraForm
    {

        public WatsonTcpServer server = null;
        public PacketDTO currentPacket;
        public Plc plc = null;
        public  TagDTO tagDto;
        public string str;
        public string serverIp;
        public List<string> clients;
        public string ipPort;
        public Utils.TypeCommand currentServerCommand;


        public MainFm()
        {
            InitializeComponent();

            startServerBtn.Enabled = false;

            //bool runForever = true;
            //while (runForever)
            //{
            //    Console.Write("Command [q cls list send]: ");
            //    string userInput = Console.ReadLine();
            //    if (String.IsNullOrEmpty(userInput)) continue;

            //    List<string> clients;
            //    string ipPort;

            
            //}
        }

        public bool ClientConnected(string ipPort)
        {
            Console.WriteLine("Client connected: " + ipPort);
            return true;
        }

        public bool ClientDisconnected(string ipPort)
        {
            Console.WriteLine("Client disconnected: " + ipPort);
            return true;
        }

        public bool MessageReceived(string ipPort, byte[] data)
        {
            Object receivedObject = new Object();

            if (data != null && data.Length > 0)
            {  
                receivedObject = ByteArrayToObject(data);
                messageEdit.MaskBox.AppendText(DateTime.Now + " Client: " + ipPort + ", command: " + ((PacketDTO)receivedObject).typeCommand + Environment.NewLine);
            }

            switch (((PacketDTO)receivedObject).typeCommand)
            {
                //case Utils.Command.Get_server_plc_db1:
                //    plc = new Plc(CpuType.S71200, "192.168.1.54", 0, 1);
                //    plc.Open();

                //    str = string.Empty;
                //    for (int i = 0; i < 254; i++)
                //        str += "\0";

                //    tagDto = new TagDTO();

                //    tagDto.CurrentWeight = Math.Round(((uint)plc.Read("DB1.DBD0.0")).ConvertToDouble(), 2);
                //    tagDto.OldWeight = ((uint)plc.Read("DB1.DBD4.0")).ConvertToDouble();
                //    tagDto.CellNumber = ((ushort)plc.Read("DB1.DBW8.0")).ConvertToShort();
                //    tagDto.PLCLoadStatus = ((ushort)plc.Read("DB1.DBW10.0")).ConvertToShort();
                //    tagDto.PLCSetOpen = ((ushort)plc.Read("DB1.DBW12.0")).ConvertToShort();
                //    tagDto.PLCSetClose = ((ushort)plc.Read("DB1.DBW14.0")).ConvertToShort();
                //    tagDto.PLCDropoffWind = ((ushort)plc.Read("DB1.DBW16.0")).ConvertToShort();
                //    tagDto.Error = (bool)plc.Read("DB1.DBX18.0");
                //    tagDto.ErrorList = S7.Net.Types.String.FromByteArray(ReadMultipleBytes(plc, 9, 1, 22));
                //    tagDto.Reset = (bool)plc.Read("DB1.DBX276.0");

                //    currentPacket = new PacketDTO(Utils.Command.Get_server_plc_db1, Convert.ToString(DateTime.Now), ObjectToByteArray((Object)tagDto));
                //    server.Send(ipPort, ObjectToByteArray((Object)currentPacket));

                //    break;
                //case Utils.Command.Get_server_plc_db27:
                //    plc = new Plc(CpuType.S71200, "192.168.1.54", 0, 1);
                //    plc.Open();

                //    str = string.Empty;
                //    for (int i = 0; i < 254; i++)
                //        str += "\0";

                //    tagDto = new TagDTO();

                //    tagDto.CurrentWeight = Math.Round(((uint)plc.Read("DB27.DBD0.0")).ConvertToDouble(), 2);
                //    tagDto.OldWeight = ((uint)plc.Read("DB27.DBD4.0")).ConvertToDouble();
                //    tagDto.CellNumber = ((ushort)plc.Read("DB27.DBW8.0")).ConvertToShort();
                //    tagDto.PLCLoadStatus = ((ushort)plc.Read("DB27.DBW10.0")).ConvertToShort();
                //    tagDto.PLCSetOpen = ((ushort)plc.Read("DB27.DBW12.0")).ConvertToShort();
                //    tagDto.PLCSetClose = ((ushort)plc.Read("DB27.DBW14.0")).ConvertToShort();
                //    tagDto.PLCDropoffWind = ((ushort)plc.Read("DB27.DBW16.0")).ConvertToShort();
                //    tagDto.Error = (bool)plc.Read("DB27.DBX18.0");
                //    tagDto.ErrorList = S7.Net.Types.String.FromByteArray(ReadMultipleBytes(plc, 9, 1, 22));
                //    tagDto.Reset = (bool)plc.Read("DB27.DBX276.0");

                //    currentPacket = new PacketDTO(Utils.Command.Get_server_plc_db27, Convert.ToString(DateTime.Now), ObjectToByteArray((Object)tagDto));
                //    server.Send(ipPort, ObjectToByteArray((Object)currentPacket));

                //    break;
                //case Utils.Command.Get_server_plc_db28:
                //    plc = new Plc(CpuType.S71200, "192.168.1.54", 0, 1);
                //    plc.Open();

                //    str = string.Empty;
                //    for (int i = 0; i < 254; i++)
                //        str += "\0";

                //    tagDto = new TagDTO();

                //    tagDto.CurrentWeight = Math.Round(((uint)plc.Read("DB28.DBD0.0")).ConvertToDouble(), 2);
                //    tagDto.OldWeight = ((uint)plc.Read("DB28.DBD4.0")).ConvertToDouble();
                //    tagDto.CellNumber = ((ushort)plc.Read("DB28.DBW8.0")).ConvertToShort();
                //    tagDto.PLCLoadStatus = ((ushort)plc.Read("DB28.DBW10.0")).ConvertToShort();
                //    tagDto.PLCSetOpen = ((ushort)plc.Read("DB28.DBW12.0")).ConvertToShort();
                //    tagDto.PLCSetClose = ((ushort)plc.Read("DB28.DBW14.0")).ConvertToShort();
                //    tagDto.PLCDropoffWind = ((ushort)plc.Read("DB28.DBW16.0")).ConvertToShort();
                //    tagDto.Error = (bool)plc.Read("DB28.DBX18.0");
                //    tagDto.ErrorList = S7.Net.Types.String.FromByteArray(ReadMultipleBytes(plc, 9, 1, 22));
                //    tagDto.Reset = (bool)plc.Read("DB28.DBX276.0");

                //    currentPacket = new PacketDTO(Utils.Command.Get_server_plc_db28, Convert.ToString(DateTime.Now), ObjectToByteArray((Object)tagDto));
                //    server.Send(ipPort, ObjectToByteArray((Object)currentPacket));

                //    break;
                //case Utils.Command.Get_server_plc_db29:
                //    plc = new Plc(CpuType.S71200, "192.168.1.54", 0, 1);
                //    plc.Open();

                //    str = string.Empty;
                //    for (int i = 0; i < 254; i++)
                //        str += "\0";

                //    tagDto = new TagDTO();

                //    tagDto.CurrentWeight = Math.Round(((uint)plc.Read("DB29.DBD0.0")).ConvertToDouble(), 2);
                //    tagDto.OldWeight = ((uint)plc.Read("DB29.DBD4.0")).ConvertToDouble();
                //    tagDto.CellNumber = ((ushort)plc.Read("DB29.DBW8.0")).ConvertToShort();
                //    tagDto.PLCLoadStatus = ((ushort)plc.Read("DB29.DBW10.0")).ConvertToShort();
                //    tagDto.PLCSetOpen = ((ushort)plc.Read("DB29.DBW12.0")).ConvertToShort();
                //    tagDto.PLCSetClose = ((ushort)plc.Read("DB29.DBW14.0")).ConvertToShort();
                //    tagDto.PLCDropoffWind = ((ushort)plc.Read("DB29.DBW16.0")).ConvertToShort();
                //    tagDto.Error = (bool)plc.Read("DB29.DBX18.0");
                //    tagDto.ErrorList = S7.Net.Types.String.FromByteArray(ReadMultipleBytes(plc, 9, 1, 22));
                //    tagDto.Reset = (bool)plc.Read("DB29.DBX276.0");

                //    currentPacket = new PacketDTO(Utils.Command.Get_server_plc_db29, Convert.ToString(DateTime.Now), ObjectToByteArray((Object)tagDto));
                //    server.Send(ipPort, ObjectToByteArray((Object)currentPacket));

                    //break;
                
                default:
                    //currentPacket = new PacketDTO(Utils.Command.Not_correct_command, "Не поддерживаемая команда", null);
                    server.Send(ipPort, ObjectToByteArray((Object)currentPacket));
                    break;
            }


            messageEdit.MaskBox.AppendText(DateTime.Now + " Message from: "+ ipPort + ", " + ((PacketDTO)receivedObject).message + Environment.NewLine);
            return true;
        }


        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }



        public Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }

        public byte[] ReadMultipleBytes(Plc plc, int numBytes, int db, int startByteAdr = 0)
        {
            List<byte> resultBytes = new List<byte>();
            int index = startByteAdr;
            while (numBytes > 0)
            {
                var maxToRead = (int)Math.Min(numBytes, 200);
                byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, index, (int)maxToRead);
                if (bytes == null)
                    return new List<byte>().ToArray<byte>();
                resultBytes.AddRange(bytes);
                numBytes -= maxToRead;
                index += maxToRead;
            }
            return resultBytes.ToArray<byte>();
        }

        private void startServerBtn_Click(object sender, EventArgs e)
        {
            if (server == null)
            {
                try
                {
                    server = new WatsonTcpServer(serverIp, 9000, ClientConnected, ClientDisconnected, MessageReceived, true);
                    startServerBtn.Text = "Остановить";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при запуске сервера.\n" + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                server = null;
                startServerBtn.Text = "Запустить";
            }
            
        }

        private void startCommandBtn_Click(object sender, EventArgs e)
        {
            switch (currentServerCommand)
            {
                //case Utils.Command.Get_server_plc_db1:
                //    //runForever = false;
                //    break;
                //case Utils.Command.Get_server_plc_db27:
                //    //Console.Clear();
                //    break;
                //case Utils.Command.Get_server_plc_db28:
                //    //clients = server.ListClients();
                //    //if (clients != null && clients.Count > 0)
                //    //{
                //    //    Console.WriteLine("Clients");
                //    //    foreach (string curr in clients) Console.WriteLine("  " + curr);
                //    //}
                //    //else Console.WriteLine("None");
                //    break;
                //case Utils.Command.Get_server_plc_db29:
                //    //Console.Write("IP:Port: ");
                //    //ipPort = Console.ReadLine();


                //    //BinaryFormatter formatter;

                //    ////var stream = new MemoryStream();

                //    ////formatter.Serialize(stream, tm);

                //    //TagDTO tagDto = new TagDTO();
                //    //tagDto.CurrentWeight = 10;
                //    //tagDto.OldWeight = 10;



                //    ////if (String.IsNullOrEmpty(userInput)) break;



                //    ////server.Send(ipPort, Encoding.UTF8.GetBytes(userInput));

                //    //server.Send(ipPort, ObjectToByteArray(tagDto));

                //    break;
            }
        }

        private void serverIpEdit_EditValueChanged(object sender, EventArgs e)
        {
            serverIp = serverIpEdit.Text;

            if (serverIp == "")
            {
                startServerBtn.Enabled = false;
                startCommandBtn.Enabled = false;
            }
            else
            {
                startServerBtn.Enabled = true;
                startCommandBtn.Enabled = true;
            }
        }

    }
}