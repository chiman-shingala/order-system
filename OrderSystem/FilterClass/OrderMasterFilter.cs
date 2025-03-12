
namespace OrderSystem.FilterClass
{
    public partial class OrderMasterFilter
    {
        public string[]? CompanyId { get; set; }
        public int UserId { get; set; }
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }

        public string? InvoiceNo { get; set; }
        public int AcYear { get; set; }
        public decimal FromRate { get; set; }
        public decimal ToRate { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public int FromTrnNo { get; set;}
        public int ToTrnNo { get;set;}
        public int FromPcs { get; set; }
        public int ToPcs { get; set; } 
        public string[]? PartyCode { get; set; }
    }

    public partial class OrderMasterFilter
    {
        public string? CompanyIdCsv => CompanyId != null ? string.Join(",", CompanyId) : null;
        public string? PartyCodeCsv => PartyCode != null ? string.Join(",",PartyCode) : null;
    }
}

