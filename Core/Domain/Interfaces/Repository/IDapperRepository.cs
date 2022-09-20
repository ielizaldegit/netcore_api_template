using System;
using Ardalis.Specification;
using Core.Interfaces;
using System.Data;

namespace Core.Domain.Interfaces.Repository;

public interface IDapperRepository : ITransientService
{

    Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType type = CommandType.Text, CancellationToken cancellationToken = default)
    where T : class;

    Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType type = CommandType.Text, CancellationToken cancellationToken = default)
    where T : class;

    Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType type = CommandType.Text, CancellationToken cancellationToken = default)
    where T : class;
}

