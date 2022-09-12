using System.Net;
using System.Text.Json;

namespace API.Helpers.Errors
{

    //[Serializable]
    //public class BadRequestException : Exception
    //{
    //    public BadRequestException() : base() { }
    //    public BadRequestException(string message) : base(message) { }
    //    public BadRequestException(string message, Exception inner) : base(message, inner) { }
    //}

    //[Serializable]
    //public class UnauthorizedException : Exception
    //{
    //    public UnauthorizedException() : base() { }
    //    public UnauthorizedException(string message) : base(message) { }
    //    public UnauthorizedException(string message, Exception inner) : base(message, inner) { }
    //}

    //[Serializable]
    //public class NotFoundException : Exception
    //{
    //    public NotFoundException() : base() { }
    //    public NotFoundException(string message) : base(message) { }
    //    public NotFoundException(string message, Exception inner) : base(message, inner) { }
    //}

    //public class ApiResponse
    //{
    //    public int StatusCode { get; set; }
    //    public string Message { get; set; }

    //    public ApiResponse(int statusCode, string message = null)
    //    {
    //        StatusCode = statusCode;
    //        Message = message ?? GetDefaultMessage(statusCode);
    //    }

    //    private string GetDefaultMessage(int statusCode)
    //    {
    //        return statusCode switch
    //        {
    //            400 => "Has realizado una petición incorrecta.",
    //            401 => "Usuario no autorizado.",
    //            404 => "El recurso que has intentado solicitar no existe.",
    //            405 => "Este método HTTP no está permitido en el servidor.",
    //            500 => "Error en el servidor. Comunícate con el administrador.",
    //            _ => "Error desconocido."
    //        };
    //    }
    //}


    //public class ApiException : ApiResponse
    //{
    //    public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message)
    //    {
    //        Details = details;
    //    }

    //    public string Details { get; set; }
    //}


    //public class ExceptionMiddleware
    //{
    //    private readonly RequestDelegate _next;
    //    private readonly ILogger<ExceptionMiddleware> _logger;
    //    private readonly IHostEnvironment _env;

    //    public ExceptionMiddleware(RequestDelegate next,
    //        ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    //    {
    //        _next = next;
    //        _logger = logger;
    //        _env = env;
    //    }

    //    public async Task InvokeAsync(HttpContext context)
    //    {
    //        try
    //        {
    //            await _next(context);
    //        }
    //        catch (Exception ex)
    //        {
    //            var statusCode = (int)HttpStatusCode.InternalServerError;

    //            _logger.LogError(ex, ex.Message);
    //            context.Response.ContentType = "application/json";
    //            context.Response.StatusCode = statusCode;

    //            var response = _env.IsDevelopment()
    //                            ? new ApiException(statusCode, ex.Message, ex.StackTrace.ToString())
    //                            : new ApiException(statusCode);

    //            var options = new JsonSerializerOptions
    //            {
    //                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
    //            };
    //            var json = JsonSerializer.Serialize(response, options);

    //            await context.Response.WriteAsync(json);

    //        }
    //    }

    //}



    //public class ApiValidation : ApiResponse
    //{
    //    public ApiValidation() : base(400){}
    //    public IEnumerable<string> Errors { get; set; }

    //}

}

