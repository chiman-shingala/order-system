using AutoMapper;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class UserCategoryMasterService : IUserCategoryMasterService
    {
        private readonly IUserCategoryMasterRepository _repository;
        private readonly IMapper _mapper;

        public UserCategoryMasterService(IUserCategoryMasterRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<UserCategoryMasterDto>> GetAllUserCategoryAsync()
        {
            var records = await _repository.GetAllUserCategoryAsync();
            return _mapper.Map<List<UserCategoryMasterDto>>(records);
        }
        public async Task<int> AddUserCategoryAsync(UserCategoryMasterDto categoryMaster)
        {
            var records = await _repository.AddUserCategoryAsync(categoryMaster);
            return records;
        }
        public async Task<int> UpdateUserCategoryAsync(UserCategoryMasterDto categoryMaster)
        {
            var records = await _repository.UpdateUserCategoryAsync(categoryMaster);
            return records;
        }
        public async Task<int> DeleteUserCategoryAsync(int userCategoryId)
        {
            var record = await _repository.DeleteUserCategoryAsync(userCategoryId);
            return record;
        }
    }
}
