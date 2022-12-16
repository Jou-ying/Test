using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test2.Models;

namespace test2.Controllers;

public class TestController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public TestController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index2()
    {
        return Content("<html><body style='color:red'>test2</body></html>", "text/html");
    }

     public IActionResult Index3()
    {
        return Content("<html><body style='color:red'>test3</body></html>", "text/html");
    }
}
