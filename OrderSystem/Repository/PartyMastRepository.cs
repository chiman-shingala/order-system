using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class PartyMastRepository : IPartyMastRepository
    {
        private readonly IDRepository _dbRepository;

        public PartyMastRepository(IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<List<PartyMastDto>> GetPartyMastDetailAsync(PartyMastFilter party)
        {
            return await _dbRepository.GetAll<PartyMastDto>("sp_Get_PartyMastDetails", party);
        }
        public async Task<int> AddPartyMastDetailAsync(PartyMastDto party)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_PartyMast", party);
        }
        public async Task<int> DeletePartyMastAsync(PartyMasterParam party)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_PartyMast", party);
        }
        public async Task<List<AgrpMast>> GetAgrpMasterAsync()
        {
            return await _dbRepository.GetAll<AgrpMast>("sp_Get_AGrpMast");
        }
        public async Task<List<PartyCodeFilter>> GetPartyCodeAsync()
        {
            return await _dbRepository.GetAll<PartyCodeFilter>("sp_Get_PartyCode");
        }
        public async Task<List<PartyMastDto>> GetAllPartyAsync(GetAllPartyPara user)
        {
            return await _dbRepository.GetAll<PartyMastDto>("sp_Get_AllParty", user);
        }
    }
}
