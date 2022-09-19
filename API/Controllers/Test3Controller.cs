using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V3;

[ApiVersion("3")]
public class TestController : VersionedApiController
{
    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

