namespace OrderSystem.UserModel
{
    public class TotalOrderDto
    {
       public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int UserCategoryId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
