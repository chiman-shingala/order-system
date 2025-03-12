using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class UserWisePartyMasterRepository : IUserWisePartyMasterRepository
    {
        private readonly IDRepository _dbRepository;
        public UserWisePartyMasterRepository(OrderSystemContext context, IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<int> AddUserWisePartyMasterAsync(AddUserWisePartyMasterPara user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_UserWisePartyMaster", user);
        }
        public async Task<UserWisePartyMasterDto> UpdateUserWisepartyMaster(string order)
        {
            return await _dbRepository.ExecuteAsyncQueryWithJson<UserWisePartyMasterDto>("sp_UpdateUserWisePartyMaster", order);
        }
        public async Task<List<UserWisePartyMasterDto>> GetPartyMasterAsync(GetUserWiseItemParameterFilter user)
        {
            return await _dbRepository.GetAll<UserWisePartyMasterDto>("sp_Get_UserWisePartyMaster", user);
        }
        public async Task<List<UserWisePartyMasterDto>> GetPartyOrderAsync(GetUserWiseItemParameterFilter user)
        {
            return await _dbRepository.GetAll<UserWisePartyMasterDto>("sp_Get_PartyForOrder", user);
        }
    }
}
