using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class AlarmsDTO : ObjectBase
    {
        public int Id { get; set; }
        public int? AlarmNumber { get; set; }
        public string AlarmText { get; set; }
    }
}
