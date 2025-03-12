using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class UserCategoryMaster
{
    public int UserCategoryId { get; set; }

    public string UserCategoryName { get; set; } = null!;

    public virtual ICollection<MenuRoleDetail> MenuRoleDetails { get; set; } = new List<MenuRoleDetail>();
}
