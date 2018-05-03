using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBHelper;
using Models;
using System.Data;


namespace DAL
{
    public class UserSerice
    {
        //注册用户
         public void Add_Users(Userinfo info)
        {
            SqlParameter[] paras = new SqlParameter[]{
               new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@NickName",info.NickName), 
               new SqlParameter("@Pwd",info.Pwd),
               
               new SqlParameter("@Email",info.Email),  
               new SqlParameter("@QQ",info.QQ),  
           };
            object obj = Helper.ExecuteScalar("Add_Users", CommandType.StoredProcedure, paras);
            //if (obj != null)
            //{
            //    int Suid = Convert.ToInt32(obj);
            //    SqlParameter[] param = new SqlParameter[]
            //  {
            //      new SqlParameter ("@Suid",SqlDbType.Int,4),
            //      new SqlParameter ("@Number",SqlDbType.Int,4),
            //      new SqlParameter ("@Name",SqlDbType.VarChar,100)
            //  };
               
            }

         //public  bool LoginIdExists(string UserId)
         //{
         //    if (GetUserByLoginId(UserId) != true;
         //        return true;
         
         //}

        //判断用户是否存在
         public  bool  GetUserByLoginId(string UserId)
         {
             Userinfo info = new Userinfo();
            info = null;
             SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId",UserId)
            };
            object obj= Helper.ExecuteScalar("GetUserByLoginId", CommandType.StoredProcedure, param);
            return Convert .ToBoolean(obj);
         }

         /// <returns></returns>
         public Userinfo GetUserById(string UserId)
         {
             List<Userinfo> list = new List<Userinfo>();
             Userinfo info = new Userinfo();
             SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@UserId",UserId)
            };
             using (SqlDataReader dr = Helper.ExecuteReader("GetUsersinfo", CommandType.StoredProcedure, parm))
             {
                 while (dr.Read())
                 {
                     //info = new ProductInfo(Convert.ToInt32(dr["ProductId"]), dr["ProductName"].ToString(), dr["Brand"].ToString(), Convert.ToDecimal(dr["Price"]), dr["PublishDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["publishDate"]), Convert.ToBoolean(dr["Vis"]));
                     info.Id = Convert.ToInt32(dr["Id"]);
                     info.UserId = dr["UserId"].ToString();
                     info.Pwd = dr["Pwd"].ToString();
                     info.NickName = dr["NickName"].ToString();
                     info.Email = dr["Email"].ToString();
                     info.QQ = dr["QQ"].ToString();

                 }
             }
             return info;
         }
    //    public static User GetUserByLoginId(string loginId)
    //    {
    //        string sql = "SELECT * FROM Users WHERE LoginId = @loginId";


    //        SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@LoginId", loginId));
    //        if (reader.Read())
    //        {
    //            User user = new User();

    //            user.Id = (int)reader["Id"];
    //            user.LoginId = (string)reader["LoginId"];
    //            user.LoginPwd = (string)reader["LoginPwd"];
    //            user.Name = (string)reader["Name"];
    //            user.QQ = (string)reader["QQ"];
    //            user.Mail = (string)reader["Mail"];

    //            reader.Close();

    //            return user;
    //        }
    //        else
    //        {
    //            reader.Close();
    //            return null;
    //        }


         public Userinfo GetUserById(int id)
         {
             string sql = "SELECT * FROM Users WHERE Id = @Id";
             SqlDataReader reader = Helper.GetReader(sql, new SqlParameter("@Id", id));
             if (reader.Read())
             {
                 Userinfo user = new Userinfo();

                 user.Id = (int)reader["Id"];
                 user.UserId = (string)reader["UserId"];
                 user.Pwd = (string)reader["Pwd"];
                 user.UserName = reader["UserName"] == DBNull.Value ? null : (string)reader["UserName"];
                 user.Email = (string)reader["Email"];
                 user.QQ = (string)reader["QQ"];

                 reader.Close();

                 return user;
             }
             else
             {
                 reader.Close();
                 return null;
             }
         }
    }

   

}
