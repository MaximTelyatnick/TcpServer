using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Units
    {
        [Key]
        public int UnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitFullName { get; set; }
        public string UnitLocalName { get; set; }
        public string UnitInternationalName { get; set; }

    }
}
