using System.ComponentModel.DataAnnotations;

namespace OrderSystem.FilterClass
{
    public class ItemsDto
    {
        public int ItemId { get; set; }
        public int CompanyId { get; set; }
        public bool Enable { get; set; }
        public string? ItemName { get; set; }
		public string? ItemRate { get; set; }
		public string? ItemCode { get; set; }
        public string? ItemImage { get; set; }
        public decimal? Mrp { get; set; }
        public string? ItemDescription { get; set; }
    }
}
