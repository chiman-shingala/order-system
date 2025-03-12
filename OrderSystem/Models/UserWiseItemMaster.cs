using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class UserWiseItemMaster
{
    public int CompanyId { get; set; }

    public int UserId { get; set; }

    public int ItemId { get; set; }

    public bool Enable { get; set; }

    public decimal? Rate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
