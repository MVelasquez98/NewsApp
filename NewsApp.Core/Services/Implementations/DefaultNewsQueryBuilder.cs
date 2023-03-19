using NewsApp.Core.Services.Contracts;
using System;

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
    }
}