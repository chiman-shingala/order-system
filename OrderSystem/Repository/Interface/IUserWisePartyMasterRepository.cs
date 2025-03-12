using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IUserWisePartyMasterRepository
    {
        Task<int> AddUserWisePartyMasterAsync(AddUserWisePartyMasterPara user);
        Task<UserWisePartyMasterDto> UpdateUserWisepartyMaster(string order);
        Task<List<UserWisePartyMasterDto>> GetPartyMasterAsync(GetUserWiseItemParameterFilter user);
        Task<List<UserWisePartyMasterDto>> GetPartyOrderAsync(GetUserWiseItemParameterFilter user);
    }
}
