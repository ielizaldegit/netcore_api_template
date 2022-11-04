using Ardalis.Specification;
using AutoMapper;
using Core.Application.Profile;
using Core.Interfaces;

namespace Core.Application.Common.Models;

public class PaginationResponse<T>
{
    public PaginationResponse(List<T> data, int count, int page, int pageSize)
    {
        Data = data;
        CurrentPage = page;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
    }

    public List<T> Data { get; set; }

    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int TotalCount { get; set; }

    public int PageSize { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => CurrentPage < TotalPages;
}



public static class PaginationResponseExtensions
{
    public static async Task<PaginationResponse<TDestination>> PaginatedListAsync<T, TDestination>(
        this IRepositoryBase<T> repository, ISpecification<T> spec, int pageNumber, int pageSize, IMapper _mapper)
        where T : class
        where TDestination : class
    {

        var result = await repository.ListAsync(spec);
        int count = result.Count();


        result = result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        return new PaginationResponse<TDestination>(_mapper.Map<List<TDestination>>(result) , count, pageNumber, pageSize);


    }
}
