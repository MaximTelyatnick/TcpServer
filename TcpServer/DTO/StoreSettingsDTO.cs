using System;

namespace TVM_WMS.SERVER.DTO
{
    public class StoreSettingsDTO
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string SettingName { get; set; }
        public int DataArea { get; set; }
    }
}
