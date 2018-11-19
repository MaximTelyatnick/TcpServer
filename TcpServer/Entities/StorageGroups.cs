using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class StorageGroups
    {
        [Key]
        public int StorageGroupId { get; set; }
        public string StorageGroupName { get; set; }
        public string Description { get; set; }
        
    }
}
