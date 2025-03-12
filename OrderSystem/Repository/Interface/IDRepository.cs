
using static Dapper.SqlMapper;

namespace OrderSystem.Repository.Interface
{
    public interface IDRepository
    {
        Task<string> GetString(string storeProc, object param = null);
        Task<string> GetStringByDynamicQuery(string query, object param = null);
        Task<T> GetFirstOrDefault<T>(string storeProc, object param = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string storeProc);
        Task<T> GetFirstOrDefaultByDynamicQuery<T>(string query, object param = null);
        Task<List<T>> GetAll<T>(string storeProc, object param = null);
        Task<GridReader> QueryMultiple(string storeProc, object param = null);
        Task < (List<T> Result, IDictionary<string, object> Output) > GetAllDictionary<T>(string storeProc, object param = null, IDictionary<string, object> output = null);
        Task<List<T>> GetAllByDynamicQuery<T>(string query, object param = null);
        Task<int> ExecuteAsyncQuery(string storeProc, object param = null);
        Task<int> ExecuteAsyncDynamicQuery(string query, object param = null);
        Task<object> GetScalar(string storeProc, object param = null);
        Task<T> ExecuteAsyncQueryWithJson<T>(string storeProc, string param);
    }
}