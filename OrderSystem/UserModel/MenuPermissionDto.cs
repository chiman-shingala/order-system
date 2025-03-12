using OrderSystem.Models;

namespace OrderSystem.UserModel
{
    public class MenuPermissionDto
    {
        public int PermissionId { get; set; }

        public int? MenuId { get; set; }

        public int? UserId { get; set; }

        //public virtual MenuMaster? Menu { get; set; }
    }
}
