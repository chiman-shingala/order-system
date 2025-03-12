using OrderSystem.ExceptionHandler;
using OrderSystem.Repository.Interface;

namespace OrderSystem.Repository
{
    public class ExceptionRepository : IExceptionRepository
    {
        private readonly IDRepository _dbRepository;

        public ExceptionRepository(IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<int> AddErrorAsync(ExceptionAddParaModel error)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_add_ErrorMessage", error);
        }
    }
}
