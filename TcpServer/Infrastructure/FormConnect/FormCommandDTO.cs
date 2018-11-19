using Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVM_WMS.SERVER.Infrastructure.FormConnect
{
    public class FormCommandDTO
    {
        public Utils.TypeCommand? typeCommand { get; set; }
        public Utils.ControlCommand? controlCommand { get; set; }
        public string message { get; set; }

        public FormCommandDTO(Utils.TypeCommand? typeCommand, Utils.ControlCommand? controlCommand, string message)
        {
            this.typeCommand = typeCommand;
            this.controlCommand = controlCommand;
            this.message = message;
        }
    }
}
