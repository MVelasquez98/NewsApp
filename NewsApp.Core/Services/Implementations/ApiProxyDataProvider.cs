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
        private readonly HttpClient _httpClient;

        public ApiProxyDataProvider(HttpClient httpClient ,INewApiProxysService newsProxyService)
        {
            _httpClient = httpClient;
            _newsProxyService = newsProxyService;
        }

        public async Task<List<Article>> GetNewsAsync(string query)
        {
            var result = await _newsProxyService.GetNewsAsync(query);
            return result;
        }

        public async Task<List<Article>> GetTopHeadlinesAsync(string query)
        {
            var result = await _newsProxyService.GetTopHeadlinesAsync(query);
            return result;
        }
    }
}

