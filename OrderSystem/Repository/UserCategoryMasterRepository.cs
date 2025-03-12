using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class UserCategoryMasterRepository : IUserCategoryMasterRepository
    {
        private readonly OrderSystemContext _context;
        private readonly IDRepository _dbRepository;
        public UserCategoryMasterRepository(OrderSystemContext context, IDRepository dbRepository)
        {
            _context = context;
            _dbRepository = dbRepository;
        }
        public async Task<List<UserCategoryMaster>> GetAllUserCategoryAsync()
        {
            return await _dbRepository.GetAll<UserCategoryMaster>("sp_Get_UserCategoryMaster");
        }
        public async Task<int> AddUserCategoryAsync(UserCategoryMasterDto categoryMaster)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_UserCategoryMaster", categoryMaster);
        }
        public async Task<int> UpdateUserCategoryAsync(UserCategoryMasterDto categoryMaster)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_UserCategoryMaster", categoryMaster);
        }
        public async Task<int> DeleteUserCategoryAsync(int userCategoryId)
        {
            
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_UserCategoryMaster", userCategoryId);

        }
    }
}
