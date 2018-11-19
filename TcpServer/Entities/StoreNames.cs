using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class StoreNames
    {
        [Key]
        public int StoreNameId { get; set; }
        public string Name { get; set; }
        public int? CellCount { get; set; }
        public int? LineCount { get; set; }
        public int? ColumnCount { get; set; }
        public int? ParentId { get; set; }
        public int? EnumerationTypeId { get; set; }
        public int? StoreTypeId { get; set; }
        public int EnableAuthomatization { get; set; }
    }
}
