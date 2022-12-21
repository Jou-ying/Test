using MySql.Data.MySqlClient;
using Dapper;

namespace test2.dao;

public class login_logs: zoe {


    // 查詢 login_logs資料表
    // dynamic 弱型別
    public List<dynamic> queryAll()
    {

        String sql = "select * from login_logs";
        connect.Open();
        List<dynamic> usersData = connect.Query(sql).ToList();
        connect.Close();

        return usersData;
    }


    // 查詢 login_logs資料表
    // 強型別
     public List<login_log> queryAll2()
    {
        
        String sql = "select * from login_logs";
        connect.Open();
        List<login_log> usersData = connect.Query<login_log>(sql).ToList();
        connect.Close();

        return usersData;
    }


        public List<login_log> queryByDate(String date1)
    {
        
        String sql = "select * from login_logs where login_time like @dateX";
        connect.Open();
        List<login_log> usersData = connect.Query<login_log>(sql,new { dateX = date1+"%"}).ToList();
        connect.Close();

        return usersData;
    }



    // 新增單筆資料
     public int insert(login_log obj1)
    {
        
        // String sql = "select * from login_logs";
        String sql = "insert into login_logs(id,login_time,memo) values (@id,@login_time,@memo)";
        
        connect.Open();
        int i1 = connect.Execute(sql, obj1);
        connect.Close();
        return i1;
    }


    // 新增多筆資料
     public int update(login_log obj1)
    {
        
        // String sql = "select * from login_logs";
        String sql = "update login_logs set memo = @memo where id = @id and login_time = @login_time";
        
        connect.Open();
        int i1 = connect.Execute(sql, obj1);
        connect.Close();
        return i1;
    }


     // 新增多筆資料
     public int delete(login_log obj1)
    {
        
        // String sql = "select * from login_logs";
        String sql = "delete from login_logs where id = @id and login_time = @login_time";
        
        connect.Open();
        int i1 = connect.Execute(sql, obj1);
        connect.Close();
        return i1;
    }

}