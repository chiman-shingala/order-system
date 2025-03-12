using OrderSystem.FilterClass;

namespace OrderSystem.Repository.Interface
{
    public interface IUtilityRepository
    {
        Task<int> SetCompanyActiveInactiveAsync(ActiveInactiveCompanyFilter user);
        Task<int> SetUserActiveInactiveAsync(ActiveInactiveUserFilter user);
    }
}
