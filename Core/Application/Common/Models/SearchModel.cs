using System;
namespace Core.Application.Common.Models;


public class BaseFilter
{
    public Search? Search { get; set; }
    public Pagination? Pagination { get; set; }
    public string[]? OrderBy { get; set; }
}


public class Search
{
    public List<string> Fields { get; set; } = new();
    public string? Keyword { get; set; }
}


public class Pagination
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = int.MaxValue;


}

public static class FilterExtensions
{
    public static bool HasOrderBy(this BaseFilter filter) => filter.OrderBy?.Any() is true;
}


