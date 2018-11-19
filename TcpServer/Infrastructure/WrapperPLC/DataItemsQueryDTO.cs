using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVM_WMS.SERVER
{
    public class DataItemsQueryDTO
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public bool CanListen { get; set; }
        public int ParentDeviceId { get; set; }
        public string Offset { get; set; }
        public int ItemTypeId { get; set; }
        public string TypeName { get; set; }
        public string DeviceName { get; set; }
        public string AbsoleteItemName { get; set; }
        public string CurrentValue { get; set; }
        public string LastUpdateTime { get; set; }
    }
}
