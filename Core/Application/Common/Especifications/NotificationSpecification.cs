using System;
using Ardalis.Specification;
using Core.Domain.Entities.Mail;
using Core.Entities.Auth;

namespace Core.Application.Common.Especifications;


public class TemplateById : Specification<Template>
{
    public TemplateById(int TemplateId)
    {
        Query.Where(u => u.TemplateId == TemplateId);

    }
}