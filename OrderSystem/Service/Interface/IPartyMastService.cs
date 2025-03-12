using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IPartyMastService
    {
        Task<List<PartyMastDto>> GetPartyMastDetailAsync(PartyMastFilter party);
        Task<List<PartyMast>> AddPartyMastDetailAsync(PartyMastDto party);
        Task<int> DeletePartyMastAsync(PartyMasterParam party);
        Task<List<AgrpMast>> GetAgrpMasterAsync();
        Task<List<PartyCodeFilter>> GetPartyCodeAsync();
        Task<List<PartyMastDto>> GetAllPartyAsync(GetAllPartyPara user);
    }
}
