using AutoMapper;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class GlobalSearchService : IGlobalSearchService
    {
        private readonly IGlobalSearchRepository _repository;
        private readonly IMapper _mapper;

        public GlobalSearchService(IGlobalSearchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GlobalSearchDto>> GetGlobalSearchAsync(GlobalSearchFilter global)
        {
            var records = await _repository.GetGlobalSearchAsync(global);
            return _mapper.Map<List<GlobalSearchDto>>(records);
        }
    }
}
