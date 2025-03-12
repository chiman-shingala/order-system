using OrderSystem.Models;

namespace OrderSystem.UserModel
{
    public class UserWiseItemMasterDto
    {
        public int CompanyId { get; set; }

        public int UserId { get; set; }

        public int ItemId { get; set; }

        public bool? Enable { get; set; }

        public decimal? Rate { get; set; }

    }
}
