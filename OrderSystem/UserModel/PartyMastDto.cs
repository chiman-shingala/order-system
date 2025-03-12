namespace OrderSystem.UserModel
{
    public class PartyMastDto
    {
        public string PartyCode { get; set; } = null!;

        public int AcYear { get; set; }

        public int CompanyId { get; set; }

        public string? PartyName { get; set; }

        public int? Agrcode { get; set; }
        public int DueDays { get; set; }    
        public string? ReferenceName { get; set; }

        public string? Add1 { get; set; }

        public string? Add2 { get; set; }

        public string? Add3 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Mobile { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? Email { get; set; }

        public string? PanNo { get; set; }

        public string? Gstno { get; set; }

        public string? Remark { get; set; }
        public int UserId { get; set; }
    }
}
