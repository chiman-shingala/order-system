using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IMenuMasterService
    {
        Task<List<MenuMasterDto>> GetAllMenuMasterAsync();
        Task<List<MenuMasterDto>> GetMenuMasterRole(UserDto userDto);
        Task<int> AddMenuMasterAsync(MenuMasterDto menu);
        Task<int> UpdateMenuMasterAsync(MenuMasterDto menu);
        Task<int> DeleteMenuMasterAsync(int Id);
    }
}
