using MySql.Data.MySqlClient;
using Dapper;

namespace test2.dao;

public class users: zoe {

    // 弱型別
    public List<dynamic> queryAll()
    {
        
        String sql = "select * from users";
        
        connect2.Open();
        List<dynamic> usersData = connect2.Query(sql).ToList();
        connect2.Close();
        return usersData;
    }

    // 強型別（指定欄位名稱)
     public List<user> queryAll2()
    {        

        String sql = "select * from users";
        connect2.Open();
        List<user> usersData = connect2.Query<user>(sql).ToList();
        connect2.Close();
        return usersData;
    }

}