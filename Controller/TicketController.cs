using EventApi.Context;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class TicketController : ControllerBase
{
    private readonly MyService _myService;

    public TicketController(MyService myService)
    {
        _myService = myService;
    }

    [HttpGet]
    [Route("getTickets")]
    public IActionResult Get()
    {
        _myService.ConnectToDatabase();
        _myService.DisConnectToDatabase();
        return Ok("Connected to database successfully!");
        
    }
}