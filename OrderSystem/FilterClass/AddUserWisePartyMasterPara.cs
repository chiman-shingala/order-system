namespace OrderSystem.FilterClass
{
    public class AddUserWisePartyMasterPara
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public string? PartyCode { get; set; }
        public bool Enable { get; set; }
    }
}
