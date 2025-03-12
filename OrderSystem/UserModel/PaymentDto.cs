namespace OrderSystem.UserModel
{
    public class PaymentDto
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
    }
}
