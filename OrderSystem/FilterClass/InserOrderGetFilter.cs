namespace OrderSystem.FilterClass
{
    public class InserOrderGetFilter
    {
        public int TrnNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime TrnDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
