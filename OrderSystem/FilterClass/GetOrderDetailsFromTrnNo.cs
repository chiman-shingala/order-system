namespace OrderSystem.FilterClass
{
    public class GetOrderDetailsFromTrnNo
    {
        public int CompanyId { get; set; }

        public int AcYear { get; set; }

        public int TrnNo { get; set; }

        public int SeqNo { get; set; }

        public int ItemId { get; set; }

        public DateTime? TrnDate { get; set; }

        public decimal? Pcs { get; set; }

        public decimal Rate { get; set; }

        public decimal Amount { get; set; }
        public int DueDays { get; set; }
        public bool IsOrderConfirmed { get; set; }
        public bool IsOrderDispatched { get; set; }
        public bool IsOrderReceived { get; set; }
        public bool IsOrderReturned { get; set; }
        public string? PartyCode { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? PaymentDate { get; set; }

    }
}
