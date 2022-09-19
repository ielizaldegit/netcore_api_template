using System;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : RepositoryBase<T> where T : class
    {
        public GenericRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}

