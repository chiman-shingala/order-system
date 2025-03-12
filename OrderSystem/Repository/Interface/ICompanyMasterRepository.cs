using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface ICompanyMasterRepository
    {
        Task<List<CompanyMasterDto>> GetAllCompanyMasterAsync();
        Task<int> AddCompanyAsync(CompanyMasterDto company);
        Task<int> UpdateCompanyAsync(CompanyMasterDto company);
        Task<int> DeleteCompanyAsync(int companyId);
    }
}
