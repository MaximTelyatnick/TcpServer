using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class HistoryKeepings
    {
        [Key]
        public int Id { get; set; }
        public int KeepingId { get; set; }
        public decimal Quantity { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
