using NewsApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApp.Core.Services.Contracts
{
    public interface INewsDataProvider
    {
        Task<List<Article>> GetNewsAsync(string dateFrom, string dateTo, string keywords, int page, int pageSize);
        Task<List<Article>> GetTopHeadlinesAsync(string country, int page, int pageSize);
    }
}
