namespace OrderSystem.FilterClass
{
    public class ActiveInactiveUserFilter
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public int UpdatedBy { get; set; }
    }
}
