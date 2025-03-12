using OrderSystem.Models;

namespace OrderSystem.UserModel
{
    public class MenuMasterDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Icon { get; set; }

        public bool? IsActive { get; set; }

        public string? Path { get; set; }
        public int ParentId { get; set; }

        public int UserId { get; set; }
        

       // public virtual ICollection<MenuPermission> MenuPermissions { get; set; } = new List<MenuPermission>();
    }
}
