using NewsApp.Core.Services.Contracts;
using NewsApp.Model;
using NewsApp.Proxy.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsApp.Core.Services.Implementations
{
    public class ApiProxyDataProvider : INewsDataProvider
    {
        private readonly INewApiProxysService _newsProxyService;

        public ApiProxyDataProvider(INewApiProxysService newsProxyService)
        {
            _newsProxyService = newsProxyService;
        }
        public async Task<List<Article>> GetNewsAsync(string dateFrom, string dateTo, string keywords, int page, int pageSize, string language) => await _newsProxyService.GetNewsAsync(dateFrom, dateTo, keywords, page, pageSize, language);

        public async Task<List<Article>> GetTopHeadlinesAsync(string country, int page, int pageSize) => await _newsProxyService.GetTopHeadlinesAsync(country, page, pageSize);
    }
}

