using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class MenuRoleDetail
{
    public int MenuRoleId { get; set; }

    public int? UserCategoryId { get; set; }

    public int? MenuMasterId { get; set; }

    public virtual MenuMaster? MenuMaster { get; set; }

    public virtual UserCategoryMaster? UserCategory { get; set; }
}
