using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IUserCategoryMasterService
    {
        Task<List<UserCategoryMasterDto>> GetAllUserCategoryAsync();
        Task<int> AddUserCategoryAsync(UserCategoryMasterDto categoryMaster);
        Task<int> UpdateUserCategoryAsync(UserCategoryMasterDto categoryMaster);
        Task<int> DeleteUserCategoryAsync(int userCategoryId);
    }
}
