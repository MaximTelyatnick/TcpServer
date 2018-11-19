using Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet
{
    [Serializable]
    public class PacketDTO : Object
    {
        public Utils.TypeCommand typeCommand { get; set; }
        public Utils.ControlCommand? controlCommand { get; set; }
        public int idPlc { get; set; }
        public string namePlc { get; set; }
        public int idDb { get; set; }
        public string nameDb { get; set; }
        public string message { get; set; }
        public byte[] info { get; set; }
        //public List<DataItemsQueryDTO> ClientTaglist { get; set; }

        public PacketDTO(Utils.TypeCommand typeCommand, Utils.ControlCommand? controlCommand,  int idPlc, string namePlc, int idDb, string nameDb, string message, byte[] info)
        {
            this.typeCommand = typeCommand;
            this.controlCommand = controlCommand;
            this.idPlc = idPlc;
            this.namePlc = namePlc;
            this.idDb = idDb;
            this.nameDb = nameDb;
            this.message = message;
            this.info = info;

        }

    }

    
}
