using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IUserWiseItemMasterService
    {
        Task<List<GetUserWiseItemMasterFilter>> GetUserwiseItemAsync(GetUserWiseItemParameterFilter user);
        Task<List<GetUserWiseItemMasterDto>> GetItemForOrderAsync(GetUserWiseItemParameterFilter getUser);
        Task<GetUserWiseItemMasterDto> AddUserWiseItemMasterAsync(List<UserWiseItemMasterDto> user);
        Task<GetUserWiseItemMasterDto> UpdateUserWiseItemMasterAsync(List<UserWiseItemMasterDto> user);
        Task<int> DeleteUserWiseItemAsync(int companyId, int userId, int itemId);
    }
}
