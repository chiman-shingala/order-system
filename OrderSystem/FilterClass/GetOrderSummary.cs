namespace OrderSystem.FilterClass
{
    public class GetOrderSummary
    {
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public decimal TotalPcs { get; set; }
        public decimal AvgRate { get; set; }
        public decimal Amount { get; set; }
    }
}
