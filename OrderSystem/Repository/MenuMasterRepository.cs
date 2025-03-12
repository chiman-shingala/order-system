using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class MenuMasterRepository : IMenuMasterRepository
    {
        private readonly OrderSystemContext _context;
        private readonly IDRepository _dbRepository;

        public MenuMasterRepository(OrderSystemContext context,IDRepository dbRepository)
        {
            _context = context;
            _dbRepository = dbRepository;
        }
        public async Task<List<MenuMasterDto>> GetAllMenuMasterAsync()
        {
            return await _dbRepository.GetAll<MenuMasterDto>("sp_Get_MenuMaster");
        }
        public async Task<List<MenuMasterDto>> GetMenuMasterRole(UserDto userDto)
        {
            return await _dbRepository.GetAll<MenuMasterDto>("sp_Get_MenuRole", userDto);
        }
        public async Task<int> AddMenuMasterAsync(MenuMasterDto menu)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_MenuMaster", menu);
        }
        public async Task<int> UpdateMenuMasterAsync(MenuMasterDto menu)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_MenuMaster", menu);
        }
        public async Task<int> DeleteMenuMasterAsync(int Id)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_MenuMaster", new { Id });
        }
    }
}
