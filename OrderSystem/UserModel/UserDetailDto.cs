namespace OrderSystem.UserModel
{
    public class UserDetailDto
    {
        public string CompanyName { get; set; }

        public int UserId { get; set; }

        public string? Email { get; set; }
        public string? FirstName{ get; set; }
        public string? LastName { get; set; }   
        public string? Password { get; set; }

        public bool? IsActive { get; set; }

        public string? UserCategoryName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
