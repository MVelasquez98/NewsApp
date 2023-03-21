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
        private readonly INewsQueryBuilder _queryBuilder;

        public NewsService(INewsDataProvider newsDataProvider, INewsQueryBuilder queryBuilder)
        {
            _newsDataProvider = newsDataProvider;
            _queryBuilder = queryBuilder;
        }

        public async Task<List<Article>> GetNewsAsync(string dateFrom, string dateTo, string keywords, int page, int pageSize)
        {
            var query = _queryBuilder.BuildQuery(dateFrom, dateTo, keywords, page, pageSize);
            var result = await _newsDataProvider.GetNewsAsync(query);
            return result;
        }

        public async Task<List<Article>> GetTopHeadlinesAsync(string country, int page, int pageSize)
        {
            var query = _queryBuilder.BuildTopHeadlinesQuery(country, page, pageSize);
            var result = await _newsDataProvider.GetTopHeadlinesAsync(query);
            return result;
        }
    }

}
