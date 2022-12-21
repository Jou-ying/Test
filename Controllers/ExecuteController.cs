using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.dao;
using Newtonsoft.Json;

namespace test2.Controllers;

public class ExecuteController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ExecuteController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    

    // 查詢-Query(弱型別)
     public IActionResult Query_1()
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








    // 新增-Insert
    // 修改-Update
    // 刪除-delete

   


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

}
