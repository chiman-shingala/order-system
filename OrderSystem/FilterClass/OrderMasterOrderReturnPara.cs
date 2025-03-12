namespace OrderSystem.FilterClass
{
    public class OrderMasterOrderReturnPara
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int AcYear { get; set; }
        public int TrnNo { get; set; }
        public bool IsOrderReturned { get; set; }
    }
}
