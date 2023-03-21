using NewsApp.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsApp.Core.Services.Implementations
{
    public class DefaultNewsQueryBuilder : INewsQueryBuilder
    {
        public string BuildQuery(string dateFrom, string dateTo, string keywords, int page, int pageSize)
        {
            var query = string.Empty;

            if (!string.IsNullOrEmpty(keywords))
            {
                query += $"q={keywords}";
            }

            if (!string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
            {
                if (!string.IsNullOrEmpty(query))
                {
                    query += "&";
                }

                query += $"from={dateFrom}&to={dateTo}";
            }

            query += $"&page={page}&pageSize={pageSize}";

            return query;
        }

        public string BuildTopHeadlinesQuery(string country, int page, int pageSize)
        {
            var queryParameters = new Dictionary<string, string>
        {
            { "country", country },
            { "page", page.ToString() },
            { "pageSize", pageSize.ToString() },
        };

            var queryString = string.Join("&", queryParameters.Select(x => $"{x.Key}={x.Value}"));
            return queryString;
        }
    }
}