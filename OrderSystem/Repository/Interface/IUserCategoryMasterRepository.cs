using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IUserCategoryMasterRepository
    {
        Task<List<UserCategoryMaster>> GetAllUserCategoryAsync();
        Task<int> AddUserCategoryAsync(UserCategoryMasterDto categoryMaster);
        Task<int> UpdateUserCategoryAsync(UserCategoryMasterDto categoryMaster);
        Task<int> DeleteUserCategoryAsync(int userCategoryId);
    }
}
