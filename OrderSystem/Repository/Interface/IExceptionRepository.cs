using OrderSystem.ExceptionHandler;

namespace OrderSystem.Repository.Interface
{
    public interface IExceptionRepository
    {
        Task<int> AddErrorAsync(ExceptionAddParaModel error);
    }
}
