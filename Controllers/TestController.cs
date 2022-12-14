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
                // return "???";

        return Content("<html><body style='color:red'>test2</body></html>", "text/html");
        //return View();
    }

     public IActionResult Index3()
    {
                // return "???";

        return Content("<html><body style='color:red'>test3</body></html>", "text/html");
        //return View();
    }


}
