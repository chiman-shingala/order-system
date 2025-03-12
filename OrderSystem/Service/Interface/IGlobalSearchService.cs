using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IGlobalSearchService
    {
        Task<List<GlobalSearchDto>> GetGlobalSearchAsync(GlobalSearchFilter global);
    }
}
