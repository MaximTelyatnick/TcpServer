using Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVM_WMS.SERVER
{
    public interface ISyncPlcDriver
    {
        ConnectionStates ConnectionState { get; }

        void Connect();
        void Disconnect();
        void DisconnectVegetablePLC();
        void ReadAllVar(PlcListenVar item, int db);
        object ReadVar(string dbVar);
        byte[] ReadMultipleBytes(int numBytes, int db, int startByteAdr = 0);

        void WriteItem(string varAlias, object varValue);
        void WriteEmptyTextItem(DataItemsQueryDTO tag, int currentDB, int replicate);
    }
}
