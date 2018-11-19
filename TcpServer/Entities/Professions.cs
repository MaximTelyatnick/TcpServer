using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class Professions
    {
        [Key]
        public int Id { get; set; }
        public string ProfessionName { get; set; }

    }
}