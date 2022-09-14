using Microsoft.AspNetCore.Mvc;



namespace API.Controllers.V2;


[ApiController]
[Route("v{version:apiVersion}/[controller]")]
[ApiVersion("2")]
public class TestController : VersionedApiController
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

}

