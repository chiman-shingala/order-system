using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class ItemMaster
{
    public int ItemId { get; set; }

    public int CompanyId { get; set; }

    public string? ItemName { get; set; }

    public string? ItemCode { get; set; }

    public decimal? ItemRate { get; set; }

    public decimal? Mrp { get; set; }

    public string? ItemDescription { get; set; }

    public bool? IsActive { get; set; }

    public int? AcYear { get; set; }

    public string? ItemImage { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
