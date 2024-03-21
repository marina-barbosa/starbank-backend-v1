using Microsoft.AspNetCore.Mvc;

namespace StarBank.Controllers;

[ApiController]
[Route("hello")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHello()
    {
        return Ok("Hello world!");
    }
}