using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IPartyMastRepository
    {
        Task<List<PartyMastDto>> GetPartyMastDetailAsync(PartyMastFilter party);
        Task<int> AddPartyMastDetailAsync(PartyMastDto party);
        Task<int> DeletePartyMastAsync(PartyMasterParam party);
        Task<List<AgrpMast>> GetAgrpMasterAsync();
        Task<List<PartyCodeFilter>> GetPartyCodeAsync();
        Task<List<PartyMastDto>> GetAllPartyAsync(GetAllPartyPara user);
    }
}
