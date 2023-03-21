using NewsApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApp.Proxy.Services.Contracts
{
    public interface INewApiProxysService
    {
        Task<List<Article>> GetNewsAsync(string query);
        Task<List<Article>> GetTopHeadlinesAsync(string query);
    }
}
