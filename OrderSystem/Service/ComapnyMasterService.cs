using AutoMapper;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class ComapnyMasterService : ICompanyMasterService
    {
        private readonly ICompanyMasterRepository _repository;
        private readonly IMapper _mapper;

        public ComapnyMasterService(ICompanyMasterRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CompanyMasterDto>> GetAllCompanyMasterAsync()
        {
            var records = await _repository.GetAllCompanyMasterAsync();
            return _mapper.Map<List<CompanyMasterDto>>(records);
        }
        public async Task<int> AddNewCompanyAsync(CompanyMasterDto company)
        {
            var records = await _repository.AddCompanyAsync(company);
            return records;
        }
        public async Task<int> UpdateCompanyAsync(CompanyMasterDto company)
        {
            var records = await _repository.UpdateCompanyAsync(company);
            return records;
        }
        public async Task<int> DeleteCompanyAsync(int companyId)
        {
            var records = await _repository.DeleteCompanyAsync(companyId);
            return records;
        }
    }
}
