using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IGlobalSearchRepository
    {
        Task<List<GlobalSearchDto>> GetGlobalSearchAsync(GlobalSearchFilter global);
    }
}
