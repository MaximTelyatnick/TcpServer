using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class ZoneNamesDTO : ObjectBase
    {
        public int ZoneNameId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneColor { get; set; }
        
        public int? ZoneTypeId { get; set; }
        public string ZoneTypeName { get; set; }
        public int StoreNameId { get; set; }
    }
}
