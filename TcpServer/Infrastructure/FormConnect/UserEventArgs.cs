using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVM_WMS.SERVER.Infrastructure.FormConnect;

namespace TVM_WMS.SERVER.Infrastructure.Logger
{
    public class UserEventArgs : EventArgs
    {
        public readonly FormCommandDTO sendingInformation;

        public UserEventArgs(FormCommandDTO dt)
        {
            sendingInformation = dt;
        }
    }
}
