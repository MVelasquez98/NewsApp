using System;

namespace NewsApp.Core.Services.Contracts
{
    public interface INewsQueryBuilder
    {
        string BuildQuery(string dateFrom, string dateTo, string keywords, int page, int pageSize);
    }
}
