using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApp.Proxy.Services.Contracts;

namespace NewsProxy.Services.Implementations
{
    public class NewsApiProxyService : INewApiProxysService
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;


        public NewsApiProxyService(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = _configuration.GetSection("NewsApi:ApiKey").Value;
        }

        public async Task<List<NewsApp.Model.Article>> GetNewsAsync(string dateFrom, string dateTo, string keywords, int page, int pageSize, string language)
        {
            var newsApiClient = new NewsApiClient(_apiKey);
            Languages languageParse;
            if (!Enum.TryParse(language.ToUpper(), out languageParse))
            {
                throw new ArgumentException($"Invalid language: {language}");
            }
            var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                From = DateTime.Parse(dateFrom),
                To = DateTime.Parse(dateTo),
                Q = keywords,
                Page = page,
                PageSize = pageSize,
                Language = languageParse
            });

            return articlesResponse.Status == Statuses.Ok
                ? articlesResponse.Articles.Select(ConvertArticle).ToList()
                : new List<NewsApp.Model.Article>();
        }

        public async Task<List<NewsApp.Model.Article>> GetTopHeadlinesAsync(string country, int page, int pageSize)
        {
            var newsApiClient = new NewsApiClient(_apiKey);
            Countries countryParse;
            if (!Enum.TryParse(country.ToUpper(), out countryParse))
            {
                throw new ArgumentException($"Invalid country: {country}");
            }

            var articlesResponse = await newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
            {
                Country = countryParse,
                Page = page,
                PageSize = pageSize
            });

            return articlesResponse.Status == Statuses.Ok
                ? articlesResponse.Articles.Select(ConvertArticle).ToList()
                : new List<NewsApp.Model.Article>();
        }

        private static NewsApp.Model.Article ConvertArticle(NewsAPI.Models.Article article)
        {
            return new NewsApp.Model.Article()
            {
                Author = article.Author,
                Title = article.Title,
                Description = article.Description,
                Url = article.Url,
                UrlToImage = article.UrlToImage,
                PublishedAt = (DateTime)article.PublishedAt,
                Content = article.Content,
                Source = new NewsApp.Model.Source() { Id = article.Source.Id, Name = article.Source.Name }
            };
        }

    }
}
