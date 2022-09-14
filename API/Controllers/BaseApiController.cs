using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }

    [Route("v{version:apiVersion}/[controller]")]
    public class VersionedApiController : BaseApiController
    {
    }

    [Route("[controller]")]
    [ApiVersionNeutral]
    public class VersionNeutralApiController : BaseApiController
    {
    }



}

