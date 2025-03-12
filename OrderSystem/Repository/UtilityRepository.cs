using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;

namespace OrderSystem.Repository
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly IDRepository _dbRepository;

        public UtilityRepository(IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<int> SetCompanyActiveInactiveAsync(ActiveInactiveCompanyFilter user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_ActiveInactiveCompany", user);
        }
        public async Task<int> SetUserActiveInactiveAsync(ActiveInactiveUserFilter user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_ActiveInactiveUser", user);
        }
    }
}
