using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IMenuPermissionRepository
    {
        Task<List<MenuPermissionDto>> GetAllMenuPermissionAsync();
        Task<int> AddMenuPermissionAsync(MenuPermissionDto menuPermission);
        Task<int> UpdateMenuMasterAsync(MenuPermissionDto menuPermission);
        Task<int> DeleteMenuPermissionAsync(int PermissionId);
    }
}
