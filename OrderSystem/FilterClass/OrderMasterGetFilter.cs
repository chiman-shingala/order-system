namespace OrderSystem.FilterClass
{
    public class OrderMasterGetFilter
    {
        public int CompanyId { get; set; }
        public int UsertId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string? InvoiceNo { get; set; }
        public int AcYear { get; set; }
        public decimal TrnNo { get; set; }
        public DateTime TrnDate { get; set; }
        public decimal TotalPcs { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }

        public decimal PaymentAmount { get; set; }
        public decimal AdjustAmount { get; set; }
        public decimal RemaningAmount { get; set; }
        public bool IsOrderConfirmed { get; set; }
        public bool IsOrderDispatched { get; set; }
        public bool IsOrderReceived { get; set; }
        public bool IsOrderReturned { get; set; }
        public string? PartyName { get; set; }
        
        public DateTime? PaymentDate { get; set; }

    }
}
