using AutoMapper;
using Newtonsoft.Json;
using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class UserWiseItemMasterService : IUserWiseItemMasterService
    {
        private readonly IUserWiseItemMasterRepository _repository;
        public UserWiseItemMasterService(IUserWiseItemMasterRepository repository,IMapper mapper)
        {
            _repository = repository;
        }
        public async Task<List<GetUserWiseItemMasterFilter>> GetUserwiseItemAsync(GetUserWiseItemParameterFilter user)
        {
            return await _repository.GetUserwiseItemAsync(user);

        }
        public async Task<List<GetUserWiseItemMasterDto>> GetItemForOrderAsync(GetUserWiseItemParameterFilter getUser)
        {
            return await _repository.GetItemForOrderAsync(getUser);
        }
        public async Task<GetUserWiseItemMasterDto> AddUserWiseItemMasterAsync(List<UserWiseItemMasterDto> user)
        {
            var json = JsonConvert.SerializeObject(user);
            var record = await _repository.AddUserWiseItemMasterAsync(json);
            return record;
        }
        public async Task<GetUserWiseItemMasterDto> UpdateUserWiseItemMasterAsync(List<UserWiseItemMasterDto> user)
        {
            var json = JsonConvert.SerializeObject(user);
            var record = await _repository.UpdateUserWiseItemMasterAsync(json);
            return record;
        }
        public async Task<int> DeleteUserWiseItemAsync(int companyId, int userId, int itemId)
        {
            var record = await _repository.DeleteUserWiseItemAsync( companyId,  userId,  itemId);
            return record;
        }
    }
}
