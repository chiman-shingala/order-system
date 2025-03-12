using AutoMapper;
using Newtonsoft.Json;
using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;
using Org.BouncyCastle.Asn1.X509;

namespace OrderSystem.Service
{
    public class UserWisePartyMasterService : IUserWisePartyMasterService
    {
        private readonly IUserWisePartyMasterRepository _repository;
        public UserWisePartyMasterService(IUserWisePartyMasterRepository repository, IMapper mapper)
        {
            _repository = repository;
        }
        public async Task<int> AddUserWisePartyMasterAsync(AddUserWisePartyMasterPara user)
        {
            var record = await _repository.AddUserWisePartyMasterAsync(user);
            return record;
        }
        public async Task<UserWisePartyMasterDto> UpdateUserWisepartyMaster(List<UpdateUserWisePartyMasterPara> party)
        {
            var json = JsonConvert.SerializeObject(party);
            var record = await _repository.UpdateUserWisepartyMaster(json);
            return record;
        }
        public async Task<List<UserWisePartyMasterDto>> GetPartyMasterAsync(GetUserWiseItemParameterFilter user)
        {
            return await _repository.GetPartyMasterAsync(user);
        }
        public async Task<List<UserWisePartyMasterDto>> GetPartyOrderAsync(GetUserWiseItemParameterFilter user)
        {
            return await _repository.GetPartyOrderAsync(user);
        }
    }
}
