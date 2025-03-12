using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IUserWiseItemMasterRepository
    {
        Task<List<GetUserWiseItemMasterFilter>> GetUserwiseItemAsync(GetUserWiseItemParameterFilter user);
        Task<List<GetUserWiseItemMasterDto>> GetItemForOrderAsync(GetUserWiseItemParameterFilter getUser);
        Task<GetUserWiseItemMasterDto> AddUserWiseItemMasterAsync(string user);
        Task<GetUserWiseItemMasterDto> UpdateUserWiseItemMasterAsync(string user);
        Task<int> DeleteUserWiseItemAsync(int companyId, int userId, int itemId);
    }
}
