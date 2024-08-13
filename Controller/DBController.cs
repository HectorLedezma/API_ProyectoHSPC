using EventApi.Context;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class MyController : ControllerBase
{
    private readonly MyService _myService;

    public MyController(MyService myService)
    {
        _myService = myService;
    }

    [HttpGet]
    [Route("getdb")]
    public IActionResult Get()
    {
        //_myService.ConnectToDatabase();
        return Ok("Connected to database successfully!");
        
    }
}
