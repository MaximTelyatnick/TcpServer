using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVM_WMS.SERVER.Infrastructure.WatchDog
{
    public class DataItemsWatchDog
    {
        public string Name { get; set; }
        public string Offset { get; set; }
        public string AbsoleteItemName { get; set; }
        public string CurrentValue { get; set; }
        public string LastUpdateTime { get; set; }

        public DataItemsWatchDog()
        {

        }

        public DataItemsWatchDog(string Name, string Offset, string AbsoluteItemName, string CurrentValue, string LastUpdateTime)
        {
            this.Name = Name;
            this.Offset = Offset;
            this.AbsoleteItemName = AbsoluteItemName;
            this.CurrentValue = CurrentValue;
            this.LastUpdateTime = LastUpdateTime;
        }
    }
}
