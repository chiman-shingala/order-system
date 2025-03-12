using System;
using System.Collections.Generic;

namespace OrderSystem.Models;

public partial class OrderDetail
{
    public int CompanyId { get; set; }

    public int AcYear { get; set; }

    public int TrnNo { get; set; }

    public int SeqNo { get; set; }

    public int ItemId { get; set; }

    public DateTime? TrnDate { get; set; }

    public decimal? Pcs { get; set; }

    public decimal Rate { get; set; }

    public decimal Amount { get; set; }

    public int? UserId { get; set; }

    public bool? IsOrderConfirmed { get; set; }

    public bool? IsOrderDispatched { get; set; }

    public bool? IsOrderReceived { get; set; }

    public bool? IsOrderReturned { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
