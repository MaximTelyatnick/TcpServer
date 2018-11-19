using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Statuses
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int StatusTypeId { get; set; }

    }
}
