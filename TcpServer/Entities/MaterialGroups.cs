using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class MaterialGroups
    {
        [Key]
        public short MaterialGroupId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short? ParentId { get; set; }

    }
}
