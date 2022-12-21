using MySql.Data.MySqlClient;
using Dapper;

namespace test2.dao;

public class user_items: zoe {

    // 弱型別
    public List<user_item> queryUserItemByUser(string id)
    {
        
        String sql = "select ui.item_id, i.item_name, ui.amount from user_items ui inner join items i on ui.item_id = i.item_id where ui.id = @id";
        
        connect.Open();

        List<user_item> usersData = connect.Query<user_item>(sql, new {id = id}).ToList();

        connect.Close();

        return usersData;
    }
}