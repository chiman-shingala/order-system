using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class GlobalSearchRepository : IGlobalSearchRepository
    {
        private readonly IDRepository _dbRepository;

        public GlobalSearchRepository(IDRepository dbRepository) 
        {
            _dbRepository = dbRepository;
        }
        public async Task<List<GlobalSearchDto>> GetGlobalSearchAsync(GlobalSearchFilter global)
        {
            return await _dbRepository.GetAll<GlobalSearchDto>("sp_Get_GlobalSearch", global);
        }
    }
}
