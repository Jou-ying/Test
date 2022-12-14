using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test2.Models;

namespace test2.Controllers;

public class Test2Controller : Controller
{
    private readonly ILogger<HomeController> _logger;

    public Test2Controller(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index2()
    {
                // return "???";

        string s = "{\"type\":\"GETBARCODEORDER_2\",\"MSISDN\":\"0908018868\"}";

        return Content(s, "text/json");
        //return View();
    }

     public IActionResult Index3()
    {
                // return "???";

        return Content("<html><body style='color:red'>test3</body></html>", "text/html");
        //return View();
    }


}
