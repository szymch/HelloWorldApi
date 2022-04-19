using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers;

[ApiController]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("HelloWorld")]
    public string HelloWorld()
    {
        return "Hello from REST API";
    }

    [HttpGet]
    [Route("BuildDate")]
    public string BuildDate()
    {
        var version = Assembly.GetExecutingAssembly().FullName.Split(',')[1].Trim();
        int buildNumber = Convert.ToInt32(version.Split('.')[2]);
            int revision = Convert.ToInt32(version.Split('.')[3]);
        DateTime buildDate = new DateTime(2000, 1, 1)
            .Add(new TimeSpan(buildNumber, 0, 0, 2 * revision, 0));
        return $"Build date: {buildDate:yyyy-MM-dd HH:mm:ss}";
    }

    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "Hello World API. Current time: " + DateTime.Now.ToString("HH:mm:ss");
    }
}
