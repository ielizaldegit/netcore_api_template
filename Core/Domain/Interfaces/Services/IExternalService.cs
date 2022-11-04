using System;
using Core.Application.Common.Models;

namespace Core.Domain.Interfaces.Services;

public interface INotificationService
{
    Task<EmailResponse> SendMail(EmailRequest request);
}

public interface IDocumentsService
{

}

public interface IStorageService
{
    Task<BlobResponse> UploadBlob(CreateBlobRequest request);
}

public interface ILookupService
{

}
