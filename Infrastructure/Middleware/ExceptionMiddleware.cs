using System.Net;
using Core.Common.Exceptions;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;

namespace Infrastructure.Middleware;

internal class ExceptionMiddleware : IMiddleware
{
    private readonly ICurrentUser _currentUser;
    //private readonly IStringLocalizer<ExceptionMiddleware> _localizer;
    private readonly ISerializerService _jsonSerializer;

    public ExceptionMiddleware(
        ICurrentUser currentUser,
        //IStringLocalizer<ExceptionMiddleware> localizer,
        ISerializerService jsonSerializer)
    {
        _currentUser = currentUser;
        //_localizer = localizer;
        _jsonSerializer = jsonSerializer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.MethodNotAllowed && context.Response.HasStarted == false)
            {
                var errorResult = new ErrorResult
                {
                    Exception = $"The requested resource does not support http method '{context.Request.Method}'.",
                    StatusCode = 405
                };
                errorResult.Errors = null;
                context.Response.StatusCode = 405;
                context.Response.ContentType = "application/json; charset=utf-8";
                await context.Response.WriteAsync(_jsonSerializer.Serialize(errorResult));
            }


        }
        catch (Exception exception)
        {
            string email = _currentUser.GetUserEmail() is string userEmail ? userEmail : "Anonymous";
            var userId = _currentUser.GetUserId();
            string errorId = Guid.NewGuid().ToString();

            if (userId > 0) LogContext.PushProperty("UserId", userId);
            LogContext.PushProperty("UserEmail", email);
            LogContext.PushProperty("ErrorId", errorId);
            LogContext.PushProperty("StackTrace", exception.StackTrace);

            var errorResult = new ErrorResult
            {
                Source = exception.TargetSite?.DeclaringType?.FullName,
                Exception = exception.Message.Trim(),
                ErrorId = errorId,
                SupportMessage = "Provide the ErrorId to the support team for further analysis."
            };
            errorResult.Errors!.Add(exception.Message);
            var response = context.Response;
            response.ContentType = "application/json";

            if (exception is not CustomException && exception.InnerException != null)
            {
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
            }

            switch (exception)
            {
                case CustomException e:
                    response.StatusCode = errorResult.StatusCode = (int)e.StatusCode;
                    if (e.ErrorMessages is not null)
                    {
                        errorResult.Errors = e.ErrorMessages;
                    }

                    break;

                case KeyNotFoundException:
                    response.StatusCode = errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    response.StatusCode = errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            Log.Error($"{errorResult.Exception} Request failed with Status Code {context.Response.StatusCode} and Error Id {errorId}.");
            await response.WriteAsync(_jsonSerializer.Serialize(errorResult));
        }
    }
}

