using Microsoft.AspNetCore.Mvc;

namespace StarBank.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHello() {
        return Ok("Hello world!");
    }
}