using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly IDRepository _dbRepository;
        public UserRepository(OrderSystemContext context, IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<List<UserMaster>> GetUserAsync(Login user)
        {    
            return await _dbRepository.GetAll<UserMaster>("sp_getUserForLogin", user);
        }
        public async Task<List<UserNameDto>> GetUserMasterAsync()
        {
            return await _dbRepository.GetAll<UserNameDto>("sp_GetUser");
        }
        public async Task<List<UserNameDto>> GetUserEmailIdAsync(int companyId)
        {
            return await _dbRepository.GetAll<UserNameDto>("sp_GetUserEmailId",new { companyId });
        }
        public async Task<List<UserDetailDto>> GetAllUserAsync(int CompanyId,int UserCategoryId)
        {
            return await _dbRepository.GetAll<UserDetailDto>("sp_Get_UserMaster", new { CompanyId,UserCategoryId });     
        }
        public async Task<List<UserMasterFilter>> GetUserWithAcYear()
        {
            return await _dbRepository.GetAll<UserMasterFilter>("sp_Get_UserMasterWithAccountYear");
        }
        public async Task<int> AddUserAsync(UserMasterDto user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_UserMaster", user);
        }        
        public async Task<int> UpdateUserAsync(UserMasterDto user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_UserMaster", user);
        }
        public async Task<int> DeleteUserAsync(int userId)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_UserMaster", new { userId });
        }
        public async Task<int> ChangeUserPasswordAsync(ChangePasswordDto change)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_ChangePassword", change);
        }
        public async Task<List<TopUserDto>> GetTopUserAsync(TopUserParam user)
        {
            return await _dbRepository.GetAll<TopUserDto>("sp_Get_TopUser", user);
        }
    }
}
