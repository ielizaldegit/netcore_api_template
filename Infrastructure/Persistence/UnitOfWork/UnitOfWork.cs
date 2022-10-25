using Ardalis.Specification;
using Core.Domain.Entities.Mail;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Core.Interfaces;
using Core.Interfaces.Repository;
using Infrastructure.Auth;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly ApplicationDbContext _context;
        private readonly JwtSettings _jwtSettings;

        private IAuthRepository _auth;
        private IRepositoryBase<User> _users;
        private IRepositoryBase<Role> _roles;
        private IRepositoryBase<Person> _person;

        private IRepositoryBase<Template> _mailTemplates;
        private IRepositoryBase<Activation> _mailActivations;


        public UnitOfWork(ApplicationDbContext context, IOptions<JwtSettings> jwtSettings) {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public IAuthRepository Auth {
            get { return _auth = _auth ?? new AuthRepository(_jwtSettings); }
        }

        public IRepositoryBase<User> Users {
            get { return _users = _users ?? new GenericRepository<User>(_context); }
        }

        public IRepositoryBase<Role> Roles
        {
            get { return _roles = _roles ?? new GenericRepository<Role>(_context); }
        }

        public IRepositoryBase<Person> Person
        {
            get { return _person = _person ?? new GenericRepository<Person>(_context); }
        }

        public IRepositoryBase<Template> MailTemplates
        {
            get { return _mailTemplates = _mailTemplates ?? new GenericRepository<Template>(_context); }
        }
        public IRepositoryBase<Activation> MailActivations
        {
            get { return _mailActivations = _mailActivations ?? new GenericRepository<Activation>(_context); }
        }


        public async Task<int> SaveAsync() {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context.Dispose();
        }


    }
}

