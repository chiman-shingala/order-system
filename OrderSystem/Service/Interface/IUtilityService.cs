using OrderSystem.FilterClass;

namespace OrderSystem.Service.Interface
{
    public interface IUtilityService
    {
        Task<int> SetCompanyActiveInactiveAsync(ActiveInactiveCompanyFilter user);
        Task<int> SetUserActiveInactiveAsync(ActiveInactiveUserFilter user);
    }
}
