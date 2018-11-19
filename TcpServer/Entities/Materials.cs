using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Materials
    {
        [Key]
        public int MaterialId { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public short? MaterialGroupId { get; set; }
        public int? StorageGroupId { get; set; }

        [ForeignKey("MaterialGroupId")]
        public MaterialGroups MaterialGroups { get; set; }

        [ForeignKey("StorageGroupId")]
        public StorageGroups StorageGroups { get; set; }
    }
}
