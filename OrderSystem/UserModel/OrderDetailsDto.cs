namespace OrderSystem.UserModel
{
    public class OrderDetailsDto
    {
        public int CompanyId { get; set; }

        public int AcYear { get; set; }

        public int TrnNo { get; set; }
        public string? InvoiceNo { get; set; }

        public int SeqNo { get; set; }

        public int ItemId { get; set; }

        public DateTime? TrnDate { get; set; }

        public decimal Pcs { get; set; }

        public decimal Rate { get; set; }

        public decimal Amount { get; set; }

        public int UserId { get; set; }
        public string? PartyCode { get; set; }              

    }
}
