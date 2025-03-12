using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class AccYear
{
    public int CompanyId { get; set; }

    public int AcYear { get; set; }

    public DateTime? FtrnDate { get; set; }

    public DateTime? TtrnDate { get; set; }

    public string? Remark { get; set; }
}
