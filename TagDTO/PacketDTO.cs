using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpServer;

namespace Packet
{
    [Serializable]
    public class PacketDTO : Object
    {
        public Utils.Command command { get; set; }
        public string message { get; set; }
        public byte[] info { get; set; }


        public PacketDTO(Utils.Command command, string message, byte[] info)
        {
            this.command = command;
            this.message = message;
            this.info = info;

        }

    }

    
}
