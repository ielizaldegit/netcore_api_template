﻿using Ardalis.Specification;
using Core.Domain.Entities.Mail;
using Core.Entities.Auth;
using Core.Entities.Persons;
using Core.Interfaces.Repository;

namespace Core.Interfaces;

public interface IUnitOfWork : IScopedService
{
    IAuthRepository Auth { get; }
    IRepositoryBase<User> Users { get; }
    IRepositoryBase<Role> Roles { get; }
    IRepositoryBase<Permission> Permissions { get; }
    IRepositoryBase<Module> Modules { get; }

    IRepositoryBase<Person> Person { get; }
    IRepositoryBase<Address> Addresses { get; }

    IRepositoryBase<Template> MailTemplates { get; }
    IRepositoryBase<Activation> MailActivations { get; }


    Task<int> SaveAsync();
 }


