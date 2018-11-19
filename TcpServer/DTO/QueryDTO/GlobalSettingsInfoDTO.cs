
namespace TVM_WMS.SERVER.DTO
{
    public class GlobalSettingsInfoDTO
    {
        public int Id { get; set; }
        public int? GlobalSettingId { get; set; }
        public string SettingSectionName { get; set; }

        public int? SettingKindId { get; set; }
        public string KindName { get; set; }
        public string Description { get; set; }

        public int? SettingTypeId { get; set; }

        public string SettingValue { get; set; }
        public bool Printable { get; set; }
    }
}
