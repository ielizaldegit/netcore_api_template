using System;
using Core.Entities.Auth;

namespace Core.Domain.Entities.Mail;


public class Template
{
    public int TemplateId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Content { get; set; }
    public bool IsHtml { get; set; }
    public bool IsCustom { get; set; }
}

