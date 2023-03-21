using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsApp.Core.Services.Contracts;
using NewsApp.Model;

namespace NewsApp.Core.Services.Implementations
{
    public class NewsService : INewsService
    {
        private readonly INewsDataProvider _newsDataProvider;

        public NewsService(INewsDataProvider newsDataProvider)
        {
            _newsDataProvider = newsDataProvider;
        }

        public async Task<List<Article>> GetNewsAsync(string dateFrom, string dateTo, string keywords, int page, int pageSize)
        {
            return await _newsDataProvider.GetNewsAsync(dateFrom, dateTo, keywords, page, pageSize); ;
        }

        public async Task<List<Article>> GetTopHeadlinesAsync(string country, int page, int pageSize)
        {
            return await _newsDataProvider.GetTopHeadlinesAsync(country, page, pageSize);
        }
    }

}
