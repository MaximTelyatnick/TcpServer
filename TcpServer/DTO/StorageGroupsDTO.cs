using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class StorageGroupsDTO : ObjectBase
    {
        public int StorageGroupId { get; set; }
        public string StorageGroupName { get; set; }
        public string Description { get; set; }
        public bool GroupChecked { get; set; }
    }
}
