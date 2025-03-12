using AutoMapper;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class PartyMastService : IPartyMastService 
    {
        private readonly IPartyMastRepository _repository;
        private readonly IMapper _mapper;

        public PartyMastService(IPartyMastRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<PartyMastDto>> GetPartyMastDetailAsync(PartyMastFilter party)
        {
            return await _repository.GetPartyMastDetailAsync(party);
        }
        public async Task<List<PartyMast>> AddPartyMastDetailAsync(PartyMastDto party)
        {
            var record = await _repository.AddPartyMastDetailAsync(party);
            return _mapper.Map<List<PartyMast>>(record);
        }
        public async Task<int> DeletePartyMastAsync(PartyMasterParam party)
        {
            var record = await _repository.DeletePartyMastAsync(party);
            return record;
        }
        public async Task<List<AgrpMast>> GetAgrpMasterAsync()
        {
            return await _repository.GetAgrpMasterAsync();
        }
        public async Task<List<PartyCodeFilter>> GetPartyCodeAsync()
        {
            return await _repository.GetPartyCodeAsync();
        }
        public async Task<List<PartyMastDto>> GetAllPartyAsync(GetAllPartyPara user)
        {
            return await _repository.GetAllPartyAsync(user);
        }
    }
}
