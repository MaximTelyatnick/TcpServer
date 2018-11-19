using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Contractors
    {
        [Key]

        public int ContractorId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Srn { get; set; }
        public string Tin { get; set; }

    }
}
