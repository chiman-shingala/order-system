using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class CompanyMasterRepository : ICompanyMasterRepository
    {
        private readonly OrderSystemContext _context;
        private readonly IDRepository _dbRepository;
        public CompanyMasterRepository(OrderSystemContext context,IDRepository dbRepository) 
        {
            _context = context;
            _dbRepository = dbRepository;
        }
        public async Task<List<CompanyMasterDto>> GetAllCompanyMasterAsync()
        {
            return await _dbRepository.GetAll<CompanyMasterDto>("sp_Get_CompanyMaster");
        }
        public async Task<int> AddCompanyAsync(CompanyMasterDto company)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_CompanyMaster",company); 
        }
        public async Task<int> UpdateCompanyAsync(CompanyMasterDto company)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_CompanyMaster", company);
        }
        public async Task<int> DeleteCompanyAsync(int companyId)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_CompanyMaster", new { companyId });
        }
    }
} 
