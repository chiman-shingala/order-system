namespace OrderSystem.UserModel
{
    public class OrderConfirmedDto
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int AcYear { get; set; }
        public int TrnNo { get; set; }
        public bool IsOrderConfirmed { get; set; }
    }
}
