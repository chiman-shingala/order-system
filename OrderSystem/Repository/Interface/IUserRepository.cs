using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserMaster>> GetUserAsync(Login user);
        Task<List<UserDetailDto>> GetAllUserAsync(int CompanyId,int UserCategoryId);
        Task<List<UserNameDto>> GetUserMasterAsync();
        Task<List<UserMasterFilter>> GetUserWithAcYear();
        Task<int> AddUserAsync(UserMasterDto user);
        Task<int> UpdateUserAsync(UserMasterDto user);
        Task<int> DeleteUserAsync(int userId);
        Task<int> ChangeUserPasswordAsync(ChangePasswordDto change);
        Task<List<TopUserDto>> GetTopUserAsync(TopUserParam user);
        Task<List<UserNameDto>> GetUserEmailIdAsync(int companyId);

    }
}
