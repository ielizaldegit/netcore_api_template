using System.Security.Claims;
using API.Helpers.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        public int? CurrentUserId {
            get {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity == null) return null;
                return Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }
        }

        public int? CurrentRoleId {
            get {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity == null) return null;
                return Convert.ToInt32(claimsIdentity.FindFirst("role_id")?.Value);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public ObjectResult HandleErrors(Exception ex)
        {
            return new ObjectResult(new { });

            //return ex switch
            //{
            //    BadRequestException => BadRequest(new ApiResponse(400, ex.Message)),
            //    UnauthorizedException => Unauthorized(new ApiResponse(401, ex.Message)),
            //    NotFoundException => Unauthorized(new ApiResponse(404, ex.Message)),
            //    _ => StatusCode(500, new ApiResponse(500, ex.Message)),

            //};

        }

    }
}

