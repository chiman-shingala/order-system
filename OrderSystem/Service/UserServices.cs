using AutoMapper;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;


namespace OrderSystem.Service
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserServices(IUserRepository repository,IMapper mapper,IConfiguration configuration)
        {
            _repository = repository;
             _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<List<UserMaster>> GetUserAsync(Login user)
        {
            return await _repository.GetUserAsync(user);  
        }
        public async Task<List<UserNameDto>> GetUserMasterAsync()
        {
            return await _repository.GetUserMasterAsync();
        }
        public async Task<List<UserNameDto>> GetUserEmailIdAsync(int companyId)
        {
            return await _repository.GetUserEmailIdAsync(companyId);
        }
        public async Task<List<UserDetailDto>> GetAllUserAsync(int CompanyId,int UserCategoryId)
        {
            var records = await _repository.GetAllUserAsync(CompanyId, UserCategoryId);
            return records;
        }
        public async Task<List<UserMasterFilter>> GetUserWithAcYear()
        {
            var records = await _repository.GetUserWithAcYear();
            return records;
        }
        public async Task<int> AddUserAsync(UserMasterDto user)
        {
           var record = await _repository.AddUserAsync(user);
            return record;
        }        
        public async Task<int> UpdateUserAsync(UserMasterDto user)
        {
            var record = await _repository.UpdateUserAsync(user);
            return record;
        }
        public async Task<int> DeleteUserAsync(int userId)
        {
            var record = await _repository.DeleteUserAsync(userId);
            return record;
        }
        public async Task<int> ChangeUserPasswordAsync(ChangePasswordDto change)
        {
            if (change.Password == change.NewPassword)
            {
                return 0;
            }
            var record = await _repository.ChangeUserPasswordAsync(change);
            return record;
        }
        public async Task<List<TopUserDto>> GetTopUserAsync(TopUserParam user)
        {
            var records = await _repository.GetTopUserAsync(user);
            return records;
        }
    }
}
