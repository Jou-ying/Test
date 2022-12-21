using MySql.Data.MySqlClient;
using Dapper;

namespace test2.dao;

public class punishs: zoe {


    // 查詢 login_logs資料表
    // 強型別
     public List<string> queryAll()
    {
    
        String sql = "select punish_name from punishs";
        connect.Open();
        List<string> punshsData = connect.Query<string>(sql).ToList();
        connect.Close();

        return punshsData;
    }
}