using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.dao;
using Newtonsoft.Json;

namespace test2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        users usersDao = new users();
        List<dynamic> usersList = usersDao.queryAll();
        return Content(JsonConvert.SerializeObject(usersList), "text/Json");
        
        // String s = "";
        // for(int i = 0; i<usersList.Count; i++) {
        //     s = s+"{\"id\":\"" + usersList[i].id + "\", \"name\":\"" + usersList[i].name + "\"}";

        //     if (i != usersList.Count-1) {
        //         s = s+",";
        //     }
        // }

        // return Content("["+ s +"]", "text/Json");
        // return Content("<html><body style='color:red'>"+ s +"</body></html>", "text/html");
        //return View();
    }


     public IActionResult Index2()
    {
        users usersDao = new users();
        List<user> usersList = usersDao.queryAll2();

        return Content(JsonConvert.SerializeObject(usersList), "text/Json");
        
        // String s = "";
        // for(int i = 0; i<usersList.Count; i++) {
        //     s = s+"{\"id\":\"" + usersList[i].id + "\", \"name\":\"" + usersList[i].name + "\"}";

        //     if (i != usersList.Count-1) {
        //         s = s+",";
        //     }
        // }


        // return Content("2["+ s +"]", "text/Json");
        // return Content("<html><body style='color:red'>"+ s +"</body></html>", "text/html");
        //return View();
    }



     public IActionResult Index3()
    {
        
        String s = "[{\"id\":\"001\",\"name\":\"peter\",\"account\":\"peter\",\"password\":\"123456\"},{\"id\":\"002\",\"name\":\"eason\",\"account\":\"eason\",\"password\":\"123456\"}]";

        List<user> usersList = JsonConvert.DeserializeObject<List<user>>(s);
        
        return Content("Success");
        // return Content("<html><body style='color:red'>"+ s +"</body></html>", "text/html");
        //return View();
    }


 public IActionResult Index4()
    {
        login_logs login_log_Dao = new login_logs();
        List<login_log> dataList = login_log_Dao.queryAll2();

        return Content(JsonConvert.SerializeObject(dataList), "text/Json");
        
        // String s = "";
        // for(int i = 0; i<usersList.Count; i++) {
        //     s = s+"{\"id\":\"" + usersList[i].id + "\", \"name\":\"" + usersList[i].name + "\"}";

        //     if (i != usersList.Count-1) {
        //         s = s+",";
        //     }
        // }


        // return Content("2["+ s +"]", "text/Json");
        // return Content("<html><body style='color:red'>"+ s +"</body></html>", "text/html");
        //return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
