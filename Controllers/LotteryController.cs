using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.dao;
using Newtonsoft.Json;

namespace test2.Controllers;

public class LotteryController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public LotteryController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    

    // 查詢-Query(弱型別)
     public IActionResult QueryAllGifts()
    {
        gifts giftsDao = new gifts();
        List<gift> giftsList = giftsDao.queryAll();
        return Content(JsonConvert.SerializeObject(giftsList), "text/Json");
    }



    // 查詢-Query(弱型別)
     public IActionResult getGift(string type, string winner)
    {
        gifts giftsDao = new gifts();
        List<gift> giftsList = giftsDao.queryByType(type,winner);

        Random r = new Random();
        int i = r.Next(giftsList.Count-1);

        giftsList[i].winner = winner;

        giftsDao.update(giftsList[i]);

        return Content(giftsList[i].gift_id);

    }


    // 查詢-Query(強型別)   
        public IActionResult Query_2()
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
}
