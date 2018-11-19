using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class Alarms
    {
        [Key]
        public int Id { get; set; }
        public int AlarmNumber { get; set; }
        public string AlarmText { get; set; }
    }
}
