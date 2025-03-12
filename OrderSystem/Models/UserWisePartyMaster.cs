using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class UserWisePartyMaster
{
    public string PartyCode { get; set; } = null!;

    public int CompanyId { get; set; }

    public int UserId { get; set; }

    public bool Enable { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
