namespace OrderSystem.FilterClass
{
    public class TopUserParam
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
