using NewsApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApp.Proxy.Services.Contracts
{
    public interface INewApiProxysService
    {
        Task<List<Article>> GetNewsAsync(string query, string dateTo, string keywords, int page, int pageSize);
        Task<List<Article>> GetTopHeadlinesAsync(string country, int page, int pageSize);
    }
}
