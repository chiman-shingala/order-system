namespace OrderSystem.UserModel
{
    public class CompanyMasterDto
    {
        public int CompanyId { get; set; }
        public int CompanyDetailsId { get; set; }
        public int? AcYear { get; set; }
        public DateTime? FTrnDate { get; set; }
        public DateTime? TTrnDate { get; set; }
        public string? CompanyName { get; set; }
        public string Remark { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPayment { get; set; }
        public bool? IsInvoice { get; set; }
        public string? CompanyAddress { get; set; }

        public string? ContactPersonFirstName { get; set; }

        public string? ContactPersonLastName { get; set; }

        public string? ContactNoOffice { get; set; }

        public string? ContactNoPersonal { get; set; }
        public int UserId { get; set; }
    }
}
