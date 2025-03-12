using AutoMapper;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class MenuPermissionService : IMenuPermissionService
    {
        private readonly IMenuPermissionRepository _repository;
        private readonly IMapper _mapper;

        public MenuPermissionService(IMenuPermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<MenuPermissionDto>> GetAllMenuPermissionAsync()
        {
            return await _repository.GetAllMenuPermissionAsync();
        }
        public async Task<int> AddMenuPermissionAsync(MenuPermissionDto menuPermission)
        {
            var record = await _repository.AddMenuPermissionAsync(menuPermission);
            return record;
        }
        public async Task<int> UpdateMenuPermissionAsync(MenuPermissionDto menuPermission)
        {
            var record = await _repository.AddMenuPermissionAsync(menuPermission);
            return record;
        }
        public async Task<int> DeleteMenuPermissionAsync(int PermissionId)
        {
            var record = await _repository.DeleteMenuPermissionAsync(PermissionId);
            return record;
        }
    }
}
