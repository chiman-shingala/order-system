using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class OrderMaster
{
    public int CompanyId { get; set; }

    public int AcYear { get; set; }

    public int TrnNo { get; set; }

    public string? InvoiceNo { get; set; }

    public DateTime TrnDate { get; set; }

    public decimal TotalPcs { get; set; }

    public decimal Rate { get; set; }

    public string Amount { get; set; } = null!;

    public bool? IsOrderConfirmed { get; set; }

    public bool? IsOrderDispatched { get; set; }

    public bool? IsOrderReceived { get; set; }

    public bool? IsOrderReturned { get; set; }

    public int? UserId { get; set; }

    public decimal? PaymentAmount { get; set; }

    public decimal? RemaningAmount { get; set; }

    public decimal? AdjustAmount { get; set; }

    public string? PartyCode { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
