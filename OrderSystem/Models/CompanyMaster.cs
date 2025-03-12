using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class CompanyMaster
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPayment { get; set; }

    public bool? IsInvoice { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<CompanyDetail> CompanyDetails { get; set; } = new List<CompanyDetail>();
}
