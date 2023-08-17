using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoverLocationController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLastLocation()
    {
        return Ok("");
    }
}