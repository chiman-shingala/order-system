namespace OrderSystem.FilterClass
{
    public class OrderDetailGetFilter
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set;}
        public int AcYear { get; set;}
        public DateTime TrnDate { get; set;}    
        public int TrnNo { get; set;}   
        public int SeqNo { get; set;}
        public int ItemId { get; set;}
        public string ItemCode { get; set;}
        public string ItemDescription { get; set;}
        public double Rate { get; set;}
        public double Amount { get; set;}
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
