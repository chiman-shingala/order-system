using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace OrderSystem.FilterClass
{
    public partial class OrderDetailFilter
    {
        public string[]? CompanyId { get; set; }
        public string[]? ItemId { get; set; }
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }
        public int AcYear { get; set; }
        public decimal FromRate { get; set; }
        public decimal ToRate { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public int FromTrnNo { get; set;}
        public int ToTrnNo { get;set;}
        public int FromSeqNo { get; set; }
        public int ToSeqNo { get; set;}
    }

    public partial class OrderDetailFilter
    {
        public string? CompanyIdCsv => CompanyId != null ? string.Join(",", CompanyId) : null;
        public string? ItemIdCsv => ItemId != null ? string.Join(",", ItemId) : null;
    }
}

