namespace OrderSystem.FilterClass
{
    public class GetUserWiseItemMasterDto
    {
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public decimal ItemRate { get; set; }
        public int Mrp { get; set; }    
        public string? ItemDescription { get; set; }
        public string? ItemImage { get; set; }
        public bool? Enable { get; set; }
        public string? AcYear { get; set; }
    }
}
