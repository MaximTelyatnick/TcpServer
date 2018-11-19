using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class ZoneNames
    {
        [Key]
        public int ZoneNameId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneColor { get; set; }

        public int? ZoneTypeId { get; set; }

    }
}