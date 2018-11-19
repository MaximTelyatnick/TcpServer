using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
   public  class StoreNamesDTO : ObjectBase
    {
        public int StoreNameId { get; set; }
        public string Name { get; set; }
        public int? CellCount { get; set; }
        public int? LineCount { get; set; }
        public int? ColumnCount { get; set; }
        public int? ParentId { get; set; }
        public int? EnumerationTypeId { get; set; }
        public int? StoreTypeId { get; set; }
        public string StoreTypeName { get; set; }
        public int EnableAuthomatization { get; set; }
        public string IsNumbering { get; set; }

        public string ParentName { get; set; }
    }
}
