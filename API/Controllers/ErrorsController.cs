using API.Helpers.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("errors/{code}")]
    public class ErrorsController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error(int code)
        {
            //return new ObjectResult(new ApiResponse(code));
            return new ObjectResult(new {});
        }
    }
}

