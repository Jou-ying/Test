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



    public IActionResult Heaven()
    {
        gifts giftsDao = new gifts();
        List<string> owners = giftsDao.queryHeavenOwners();

        ViewBag.owners = owners;

        // List<> usersList = usersDao.queryAll();
        // users usersDao = new users();
        // List<dynamic> usersList = usersDao.queryAll();
        // return Content(JsonConvert.SerializeObject(usersList), "text/Json");
        
        // String s = "";
        // for(int i = 0; i<usersList.Count; i++) {
        //     s = s+"{\"id\":\"" + usersList[i].id + "\", \"name\":\"" + usersList[i].name + "\"}";

        //     if (i != usersList.Count-1) {
        //         s = s+",";
        //     }
        // }

        // return Content("["+ s +"]", "text/Json");
        // return Content("<html><body style='color:red'>"+ s +"</body></html>", "text/html");
        return View();
    }


    public IActionResult Hell()
    {
        gifts giftsDao = new gifts();
        List<string> owners = giftsDao.queryHellOwners();

        ViewBag.owners = owners;

        // List<> usersList = usersDao.queryAll();
        // users usersDao = new users();
        // List<dynamic> usersList = usersDao.queryAll();
        // return Content(JsonConvert.SerializeObject(usersList), "text/Json");
        
        // String s = "";
        // for(int i = 0; i<usersList.Count; i++) {
        //     s = s+"{\"id\":\"" + usersList[i].id + "\", \"name\":\"" + usersList[i].name + "\"}";

        //     if (i != usersList.Count-1) {
        //         s = s+",";
        //     }
        // }

        // return Content("["+ s +"]", "text/Json");
        // return Content("<html><body style='color:red'>"+ s +"</body></html>", "text/html");
        return View();
    }

     // 查詢-Query(弱型別)
     public IActionResult getGift(string type, string winner)
    {
        if (string.IsNullOrEmpty(winner))
        {
            if (type == "hell")
            {
                return RedirectToAction("Hell");
            }
            else
            {
                return RedirectToAction("Heaven");
            }
        }
        
        gifts giftsDao = new gifts();
        List<gift> giftsList = giftsDao.queryByType2(type);

         for(int a = 0; a<giftsList.Count; a++) {

            if (giftsList[a].winner == winner) {
                ViewBag.gift_id = "抽獎號你已重複抽獎("+giftsList[a].gift_id+")!!!!!";
                return View();
            }
        }
        
        giftsList = giftsDao.queryByType(type,winner);


/*        List<gift> giftsList = giftsDao.queryByType2(type);

       

         if (giftsList[2].winner == winner) {
            ViewBag.gift_id = "nononononon!!!!!";
            return View();
        }*/

        // 取得抽獎亂數
        Random r = new Random();
        int i = r.Next(giftsList.Count);

        // 更新資料
        giftsList[i].winner = winner;
        giftsDao.update(giftsList[i]);

        ViewBag.gift_id = giftsList[i].gift_id;
        ViewBag.type = type;
        

        //ViewBag.gift_id = "你已重複抽獎!!!!!";

        return View();

    }



    // 查詢-Query抽獎結果
     public IActionResult getGiftResult()
    {

        gifts giftsDao = new gifts();
        List<gift> giftsList = giftsDao.queryAll();
        ViewBag.results = giftsList;
        

        return View();
    }


     // 查詢-Query(弱型別)
     public IActionResult setGarbage(string gift_id, string type, string garbage)
    {
        
        

        gifts giftsDao = new gifts();
        List<gift> giftsList = giftsDao.queryById(type,gift_id);
        giftsList[0].garbage = garbage;

        if(Convert.ToInt32(garbage) > 7) {

             // 取得抽獎亂數
             punishs punshsDao = new punishs();
             List<string> punishList = punshsDao.queryAll();
             Random r = new Random();
            int i = r.Next(punishList.Count);
            giftsList[0].punish_name = punishList[i];
        }

        giftsDao.update(giftsList[0]);
    
        return RedirectToAction("Hell");
    }




























     public IActionResult Index2(string user_id)
    {
        users usersDao = new users();
        List<user> usersList = usersDao.queryAll2();

        user_items userItemsDao = new user_items();

        for(int i = 0; i<usersList.Count; i++) {

            List<user_item> itemList = userItemsDao.queryUserItemByUser(usersList[i].id);

            usersList[i].items = itemList;
        }


        return Content(JsonConvert.SerializeObject(usersList), "text/Json");
        
        


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


    // insert 
     public IActionResult loginLog(string user_id)
    {
        login_logs login_log_Dao = new login_logs();

        login_log obj1 = new login_log();

        obj1.id = user_id;

        obj1.login_time = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

        obj1.memo = "";

        int i = login_log_Dao.insert(obj1);

        return Content(i.ToString());
    }


    
    // update 
     public IActionResult Index6()
    {
        login_logs login_log_Dao = new login_logs();

        List<login_log> dataList = login_log_Dao.queryAll2();
        
        for (int i = 0; i<dataList.Count; i++) {
            dataList[i].memo = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            int r = login_log_Dao.update(dataList[i]);
        }
        

        return Content(JsonConvert.SerializeObject(dataList), "text/Json");
    }


    // update 
     public IActionResult queryByDate(string date1)
    {
        login_logs login_log_Dao = new login_logs();

        List<login_log> dataList = login_log_Dao.queryByDate(date1);
        
        return Content(JsonConvert.SerializeObject(dataList), "text/Json");
    }


    // delete 
     public IActionResult loginLogDelete(string user_id, string login_time)
    {
        login_logs login_log_Dao = new login_logs();

        login_log obj1 = new login_log();

        obj1.id = user_id;

        obj1.login_time =login_time;

        int i = login_log_Dao.delete(obj1);

        return Content(i.ToString());
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
