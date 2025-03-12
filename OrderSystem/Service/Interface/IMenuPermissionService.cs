using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IMenuPermissionService
    {
        Task<List<MenuPermissionDto>> GetAllMenuPermissionAsync();
        Task<int> AddMenuPermissionAsync(MenuPermissionDto menuPermission);
        Task<int> UpdateMenuPermissionAsync(MenuPermissionDto menuPermission);
        Task<int> DeleteMenuPermissionAsync(int PermissionId);
    }
}
