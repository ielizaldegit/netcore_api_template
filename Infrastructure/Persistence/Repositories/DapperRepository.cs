using System.Data;
using Core.Common.Exceptions;
using Core.Domain.Interfaces.Repository;
using Dapper;
using Infrastructure.Persistence.Context;
using static Dapper.SqlMapper;

namespace Infrastructure.Persistence.Repositories;

public class DapperRepository : IDapperRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DapperRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType type = CommandType.Text, CancellationToken cancellationToken = default)
    where T : class =>
        (await _dbContext.Connection.QueryAsync<T>(sql, param, transaction, null, type)).AsList();


    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType type = CommandType.Text, CancellationToken cancellationToken = default) where T : class
    {
        var entity = await _dbContext.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, null, type);

        return entity ?? throw new NotFoundException(string.Empty);
    }

    public Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType type = CommandType.Text, CancellationToken cancellationToken = default)
    where T : class
    {
        return _dbContext.Connection.QuerySingleAsync<T>(sql, param, transaction, null, type);
    }

    public Task<GridReader> QueryMultipleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType type = CommandType.Text, CancellationToken cancellationToken = default)
    where T : class
    {
        return _dbContext.Connection.QueryMultipleAsync(sql, param, transaction, null, type);
    }

}

