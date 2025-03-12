namespace OrderSystem.UserModel
{
    public class OrderDetailByUserDto
    {
        public int SeqNo { get; set; }
        public int TrnNo { get; set; }
        public int AcYear { get; set; }
        public string Email { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime TrnDate { get; set; }
        public bool IsOrderReceived { get; set; }

        public int Pcs { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string? PartyName { get; set; }
    }
}
