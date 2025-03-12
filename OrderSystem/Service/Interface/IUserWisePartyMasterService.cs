using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IUserWisePartyMasterService
    {
        Task<int> AddUserWisePartyMasterAsync(AddUserWisePartyMasterPara user);
        Task<List<UserWisePartyMasterDto>> GetPartyMasterAsync(GetUserWiseItemParameterFilter user);
        Task<List<UserWisePartyMasterDto>> GetPartyOrderAsync(GetUserWiseItemParameterFilter user);
        Task<UserWisePartyMasterDto> UpdateUserWisepartyMaster(List<UpdateUserWisePartyMasterPara> party);
    }
}
