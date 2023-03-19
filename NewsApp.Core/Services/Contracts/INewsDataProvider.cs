using NewsApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApp.Core.Services.Contracts
{
    public interface INewsDataProvider
    {
        Task<List<Article>> GetNewsAsync(string query);
    }
}
