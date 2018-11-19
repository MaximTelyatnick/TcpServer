using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class StoreLoad
    {
        [Key]
        public int StoreNameId { get; set; }
        public int? ParentId { get; set; }
        public string StoreName { get; set; }
        public decimal? RowFullWeight { get; set; }
        public decimal? RowCurrentWeight { get; set; }
        public decimal? RowRemainsWeight { get; set; }
        public decimal? RowLoad { get; set; }
        public decimal? StoreFullWeight { get; set; }
        public decimal? StoreCurrentWeight { get; set; }
        public decimal? StoreRemainsWeight { get; set; }
        public decimal? StoreFullLoad { get; set; }
    }
}
