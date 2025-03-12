using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IUserService
    {
        Task<List<UserMaster>> GetUserAsync(Login user);
        Task<List<UserNameDto>> GetUserMasterAsync();
        Task<List<UserDetailDto>> GetAllUserAsync(int CompanyId,int UserCategoryId);
        Task<List<UserMasterFilter>> GetUserWithAcYear();
        Task<int> AddUserAsync(UserMasterDto user);
        Task<int> UpdateUserAsync(UserMasterDto user);
        Task<int> DeleteUserAsync(int userId);
        Task<int> ChangeUserPasswordAsync(ChangePasswordDto change);
        Task<List<TopUserDto>> GetTopUserAsync(TopUserParam user);
        Task<List<UserNameDto>> GetUserEmailIdAsync(int companyId);
    }
}
