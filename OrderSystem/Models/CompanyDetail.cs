using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class CompanyDetail
{
    public int CompanyId { get; set; }

    public int CompanyDetailsId { get; set; }

    public string? CompanyAddress { get; set; }

    public string? ContactPersonFirstName { get; set; }

    public string? ContactPersonLastName { get; set; }

    public string ContactNoOffice { get; set; } = null!;

    public string? ContactNoPersonal { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual CompanyMaster Company { get; set; } = null!;
}
