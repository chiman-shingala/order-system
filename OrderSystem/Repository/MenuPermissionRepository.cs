using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class MenuPermissionRepository : IMenuPermissionRepository
    {
        private readonly OrderSystemContext _context;
        private readonly IDRepository _dbRepository;

        public MenuPermissionRepository(OrderSystemContext context, IDRepository dbRepository)
        {
            _context = context;
            _dbRepository = dbRepository;
        }
        public async Task<List<MenuPermissionDto>> GetAllMenuPermissionAsync()
        {
            return await _dbRepository.GetAll<MenuPermissionDto>("sp_Get_MenuPermission");
        }
        public async Task<int> AddMenuPermissionAsync(MenuPermissionDto menuPermission)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_MenuPermission", menuPermission);
        }
        public async Task<int> UpdateMenuMasterAsync(MenuPermissionDto menuPermission)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_MenuPermission", menuPermission);
        }
        public async Task<int> DeleteMenuPermissionAsync(int PermissionId)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_MenuPermission", new { PermissionId });
        }
    }
}
