using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class MenuPermission
{
    public int PermissionId { get; set; }

    public int? MenuId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual MenuMaster? Menu { get; set; }
}
