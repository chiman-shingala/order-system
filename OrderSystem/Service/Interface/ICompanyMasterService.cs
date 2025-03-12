using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface ICompanyMasterService
    {
        Task<List<CompanyMasterDto>> GetAllCompanyMasterAsync();
        Task<int> AddNewCompanyAsync(CompanyMasterDto company);
        Task<int> UpdateCompanyAsync(CompanyMasterDto company);
        Task<int> DeleteCompanyAsync(int companyId);
    }
};
