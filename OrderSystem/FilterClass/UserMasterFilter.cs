namespace OrderSystem.FilterClass
{
    public class UserMasterFilter
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
        public int? UserCategoryId { get; set; }
        public int AcYear { get; set; }
        public string? FirstName{ get; set; }
        public string? LastName { get; set;}
    }   
}
