namespace TVM_WMS.SERVER.DTO
{
    public class MeasuresDTO
    {
        public int MeasureId { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal UnitWeight { get; set; }
        public int? UnitId { get; set; }
        public string UnitLocalName { get; set; }
        public int? PackingTypeId { get; set; }
        public string PackingName { get; set; }

        public string FullName { get; set; }

    }
}
