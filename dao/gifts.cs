using MySql.Data.MySqlClient;
using Dapper;

namespace test2.dao;

public class gifts: zoe {


    // 查詢 login_logs資料表
    // 強型別
     public List<gift> queryAll()
    {
    
        String sql = "select * from gifts";
        connect.Open();
        List<gift> giftsData = connect.Query<gift>(sql).ToList();
        connect.Close();

        return giftsData;
    }


        public List<gift> queryByType(String type, string winner)
    {
        String sql = "select * from gifts where type = @type and owner <> @winner and winner = ''";

        connect.Open();
        List<gift> usersData = connect.Query<gift>(sql,new { type = type, winner = winner}).ToList();
        connect.Close();

        return usersData;
    }


        public List<gift> queryById(String type, string gift_id)
    {
        String sql = "select * from gifts where type = @type and gift_id = @gift_id";

        connect.Open();
        List<gift> usersData = connect.Query<gift>(sql,new { type = type, gift_id = gift_id}).ToList();
        connect.Close();

        return usersData;
    }



        public List<gift> queryByType2(String type)
    {
        String sql = "select * from gifts where type = @type and winner <> ''";

        connect.Open();
        List<gift> usersData = connect.Query<gift>(sql,new { type = type}).ToList();
        connect.Close();

        return usersData;
    }


        public List<string> queryOwners()
    {
        String sql = "select distinct owner from gifts";

        connect.Open();

        List<string> usersData = connect.Query<string>(sql).ToList();
        connect.Close();

        return usersData;
    }


            public List<string> queryHeavenOwners()
    {
        String sql = "select distinct owner from gifts where type='heaven' and owner not in (select winner from gifts where type='heaven' and winner <> '')";

        connect.Open();

        List<string> usersData = connect.Query<string>(sql).ToList();
        connect.Close();

        return usersData;
    }



            public List<string> queryHellOwners()
    {
        String sql = "select distinct owner from gifts where type='hell' and owner not in (select winner from gifts where type='hell' and winner <> '')";

        connect.Open();

        List<string> usersData = connect.Query<string>(sql).ToList();
        connect.Close();

        return usersData;
    }


    // 查詢所有Heaven抽獎結果
        public List<string> queryAllHeavenGetGiftResult()
    {   
        String sql = "select * from gifts where type = 'Heaven'";

        connect.Open();

        List<string> resultData = connect.Query<string>(sql).ToList();
        connect.Close();

        return resultData;
    }


    // 查詢所有Hell抽獎結果
        public List<string> queryAllHellGetGiftResult()
    {   
        String sql = "select * from gifts where type = 'Hell'";

        connect.Open();

        List<string> resultData = connect.Query<string>(sql).ToList();
        connect.Close();

        return resultData;
    }


    // 查詢所有抽獎結果
        public List<string> queryAllGetGiftResult()
    {   
        String sql = "select from gifts where type = @type";

        connect.Open();

        List<string> resultData = connect.Query<string>(sql).ToList();
        connect.Close();

        return resultData;
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
     public int update(gift obj1)
    {
        
        String sql = "update gifts set owner = @owner, memo = @memo, winner = @winner, garbage = @garbage ,punish_name = @punish_name where gift_id = @gift_id and type = @type";
        
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