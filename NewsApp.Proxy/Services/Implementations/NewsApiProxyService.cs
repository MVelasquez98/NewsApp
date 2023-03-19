using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NewsApp.Model;
using NewsApp.Proxy.Services.Contracts;
using Newtonsoft.Json;

namespace NewsProxy.Services.Implementations
{
    public class NewsApiProxyService : INewApiProxysService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;


        public NewsApiProxyService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration.GetSection("NewsApi:ApiKey").Value;
            _baseUrl = _configuration.GetSection("NewsApi:BaseUrl").Value;
        }


        public async Task<List<Article>> GetNewsAsync(string query)
        {
            var url = $"{_baseUrl}everything?{query}&apiKey={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var newsResponse = JsonConvert.DeserializeObject<NewsApiResponse>(content);
                return newsResponse.Articles;
            }

            return null;
        }

    }
}
