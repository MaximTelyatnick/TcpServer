using Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TVM_WMS.SERVER.Infrastructure
{
    public class Client
    {
        public string ClientPort { get; set; }
        public int ClientDBId { get; set; }
        public string ClientDBName { get; set; }
        public int ClientPLCId { get; set; }
        public string ClientPLCName { get; set; }
        public Utils.StatusClient ClientStatus { get; set; }
        public List<DataItemsQueryDTO> ClientTaglist { get; set; }
        public Timer TaglistSenderTimer { get; set; }
        public Timer WatchDogTimer { get; set; }
        public Timer SyncrinizedTimer { get; set; }

        public Client()
        {
            this.ClientPort = null;
            this.ClientDBId = 0;
            this.ClientDBName = null;
            this.ClientPLCId = 0;
            this.ClientPLCName = null;
            this.ClientStatus = Utils.StatusClient.Disconnect;
            this.ClientTaglist = null;
            this.TaglistSenderTimer = null;
            this.WatchDogTimer = null;
            this.SyncrinizedTimer = null;

        }

        public Client(string ClientPort, int ClientDBId, string ClientDBName, int ClientPLCId, string ClientPLCName, Utils.StatusClient StatusClient, List<DataItemsQueryDTO> ClientTaglist, Timer TaglistSenderTimer, Timer SyncrinizedTimer)
        {
            this.ClientPort = ClientPort;
            this.ClientDBId = ClientDBId;
            this.ClientDBName = ClientDBName;
            this.ClientPLCId = ClientPLCId;
            this.ClientPLCName = ClientPLCName;
            this.ClientStatus = ClientStatus;
            this.ClientTaglist = ClientTaglist;
            this.TaglistSenderTimer = TaglistSenderTimer;
            this.WatchDogTimer = WatchDogTimer;
            this.SyncrinizedTimer = SyncrinizedTimer;
        }

    }

}
