using NewsApp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsApp.Core.Services.Contracts
{
    public interface INewsService
    {
        Task<List<Article>> GetNewsAsync(string dateFrom, string dateTo, string keywords, int page, int pageSize, string language);
        Task<List<Article>> GetTopHeadlinesAsync(string country, int page, int pageSize);
    }
}
