namespace OrderSystem.FilterClass
{
    public class OrderDetailOrderConfirmedPara
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int AcYear { get; set; }
        public int TrnNo { get; set; }
        public int SeqNo { get; set; }
        public bool IsOrderConfirmed { get; set; }
    }
}
