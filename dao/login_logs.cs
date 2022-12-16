using MySql.Data.MySqlClient;
using Dapper;

namespace test2.dao;

public class login_logs: zoe {

    public List<dynamic> queryAll()
    {

        String sql = "select * from login_logs";
        connect2.Open();
        List<dynamic> usersData = connect2.Query(sql).ToList();
        connect2.Close();

        return usersData;
    }

     public List<login_log> queryAll2()
    {
        
        String sql = "select * from login_logs";
        connect2.Open();
        List<login_log> usersData = connect2.Query<login_log>(sql).ToList();
        connect2.Close();

        return usersData;
    }

}