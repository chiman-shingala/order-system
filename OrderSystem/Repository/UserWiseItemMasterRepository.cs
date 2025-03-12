using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;
using Org.BouncyCastle.Asn1.X509;

namespace OrderSystem.Repository
{
    public class UserWiseItemMasterRepository :IUserWiseItemMasterRepository
    {
        private readonly IDRepository _dbRepository;
        public UserWiseItemMasterRepository(OrderSystemContext context, IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<List<GetUserWiseItemMasterFilter>> GetUserwiseItemAsync(GetUserWiseItemParameterFilter user)
        {
            return await _dbRepository.GetAll<GetUserWiseItemMasterFilter>("sp_Get_UserWiseItemMaster", user);
        }
        public async Task<List<GetUserWiseItemMasterDto>> GetItemForOrderAsync(GetUserWiseItemParameterFilter getUser)
        {
            return await _dbRepository.GetAll<GetUserWiseItemMasterDto>("sp_Get_ItemForOrder", getUser);
        }
        public async Task<GetUserWiseItemMasterDto> AddUserWiseItemMasterAsync(string user)
        {
            return await _dbRepository.ExecuteAsyncQueryWithJson<GetUserWiseItemMasterDto>("sp_InsertUpdateUserWiseItemMaster", user);
        }
        public async Task<GetUserWiseItemMasterDto> UpdateUserWiseItemMasterAsync(string user)
        {
            return await _dbRepository.ExecuteAsyncQueryWithJson<GetUserWiseItemMasterDto>("sp_InsertUpdateUserWiseItemMaster", user);
        }
        public async Task<int> DeleteUserWiseItemAsync(int companyId,int userId,int itemId)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_UserWiseItemMaster", new {companyId,userId,itemId});
        }
    }
}
