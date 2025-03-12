using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class OrderPayment
{
    public int CompanyId { get; set; }

    public int AcYear { get; set; }

    public int TrnNo { get; set; }

    public int SeqNo { get; set; }

    public int? UserId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? PaymentAmount { get; set; }

    public decimal? AdjustAmount { get; set; }

    public string? Remark { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
