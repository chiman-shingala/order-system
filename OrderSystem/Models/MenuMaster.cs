using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class MenuMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Icon { get; set; }

    public bool? IsActive { get; set; }

    public string? Path { get; set; }

    public int? ParentId { get; set; }

    public int? OrderByMenu { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<MenuPermission> MenuPermissions { get; set; } = new List<MenuPermission>();

    public virtual ICollection<MenuRoleDetail> MenuRoleDetails { get; set; } = new List<MenuRoleDetail>();
}
