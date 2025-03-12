namespace OrderSystem.UserModel
{
    public class GlobalSearchDto
    {
        public int SeqNo { get; set; }
        public int TrnNo { get; set; }
        public int AcYear { get; set; }
        public string? Email { get; set; }
        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime TrnDate { get; set; }
        public int Pcs { get; set; }
        public int Rate { get; set; }
        public int Amount { get; set; }
        public bool IsOrderRecevied { get; set; }
        public string? PartyName { get; set; }
        public int CompanyId { get; set; }
    }
}
