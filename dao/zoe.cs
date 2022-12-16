using MySql.Data.MySqlClient;

using Dapper;
namespace test2.dao;

public class zoe {

    // 資料庫連線
    public MySqlConnection connect2 = new MySqlConnection("server=34.82.166.62;port=3306;user id=zoe;password=rolling_tw;database=zoe;charset=utf8");

}