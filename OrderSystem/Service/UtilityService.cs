using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;


namespace OrderSystem.Service
{
    public class UtilityService : IUtilityService
    {
        private readonly IUtilityRepository _utilityRepository;

        public UtilityService(IUtilityRepository utilityRepository)
        {
            _utilityRepository = utilityRepository;
        }

        public async Task<int> SetCompanyActiveInactiveAsync(ActiveInactiveCompanyFilter user)
        {
            var record = await _utilityRepository.SetCompanyActiveInactiveAsync(user);
            return record;
        }
        public async Task<int> SetUserActiveInactiveAsync(ActiveInactiveUserFilter user)
        {
            var record = await _utilityRepository.SetUserActiveInactiveAsync(user);
            return record;
        }
    }
}
