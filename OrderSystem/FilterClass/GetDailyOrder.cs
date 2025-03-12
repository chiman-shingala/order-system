namespace OrderSystem.FilterClass
{
    public class GetDailyOrder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrderConfirmed { get; set; }
        public int OrderDispatched { get; set; }
        public int OrderReceived { get; set; }
        public int OrderReturned { get; set; }
        public int TotalOrder { get; set; }
        public int PendingOrder { get; set; }

    }
}
