using AutoMapper;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class MenuMasterService : IMenuMasterService
    {
        private readonly IMenuMasterRepository _repository;
        private readonly IMapper _mapper;


        public MenuMasterService(IMenuMasterRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<MenuMasterDto>> GetAllMenuMasterAsync()
        {
            return await _repository.GetAllMenuMasterAsync();
        }
        public async Task<List<MenuMasterDto>> GetMenuMasterRole(UserDto userDto)
        {
            var record =  await _repository.GetMenuMasterRole(userDto);
            return record;
        }
        public async Task<int> AddMenuMasterAsync(MenuMasterDto menu)
        {
           
            var record = await _repository.AddMenuMasterAsync(menu);
            return record;
        }
        public async Task<int> UpdateMenuMasterAsync(MenuMasterDto menu)
        {
            var record = await _repository.AddMenuMasterAsync(menu);
            return record;
        }
        public async Task<int> DeleteMenuMasterAsync(int Id)
        {
            var record = await _repository.DeleteMenuMasterAsync(Id);
            return record;
        }
    }
}
