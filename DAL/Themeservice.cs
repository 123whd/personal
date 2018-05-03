using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;
using DBHelper;

namespace DAL
{
    public class Themeservice
    {
        //热门文章
        public List<Themeinfo> GetModelById()
        {
            List<Themeinfo> list = new List<Themeinfo>();
            Themeinfo info = null;
            //SqlParameter[] parm = new SqlParameter[]
            //{
            //    //new SqlParameter("@ProductId",productId)
            //};
            using (SqlDataReader dr = Helper.ExecuteReader("GetThemeby", CommandType.StoredProcedure, null))
            {
                while (dr.Read())
                {
                    info = new Themeinfo();
                    info.Title = dr["Title"].ToString();
                    info.Spot = dr["Spot"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Spot"]);
                    list.Add(info);


                }
            }
            return list;
        }
        //主题内容

        public List<Themeinfo> GetTheme()
        {
            List<Themeinfo> list = new List<Themeinfo>();
            Themeinfo info = null;
            //SqlParameter[] parm = new SqlParameter[]
            //{
            //    new SqlParameter("@UserId",UserId)
            //};
            using (SqlDataReader dr = Helper.ExecuteReader("GetTheme", CommandType.StoredProcedure, null))
            {
                while (dr.Read())
                {
                    info = new Themeinfo();
                    info.ThemeId = Convert.ToInt32(dr["ThemeId"].ToString());
                    //info.UserId = Convert.ToInt32(dr["UserId"].ToString());
                    info.Title = dr["Title"].ToString();
                    //info.UserName = dr["UserName"].ToString();
                    info.T_PublishTime = dr["T_PublishTime"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["T_PublishTime"]);
                    //info.T_Content = dr["T_Content"].ToString();
                    info.Spot = dr["Spot"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Spot"]);
                    list.Add(info);


                }
            }
            return list;
        }

        //删除文章
        public bool DeleteTheme(int themeId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@ThemeId",themeId)
            };
            return Helper.ExecuteNonQuery("DeleteTheme", CommandType.StoredProcedure, param);
        }

        /// 修改文章
        public bool UpdateTheme(Themeinfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {                
                new SqlParameter ("@ThemeId",info.ThemeId),
                new SqlParameter ("@Title",info.Title ),
                //new SqlParameter("@UserName",info.UserName ),
                new SqlParameter("@T_PublishTime",info.T_PublishTime),               
                new SqlParameter("@Spot",info.Spot)
            };
            return Helper.ExecuteNonQuery("UpdateTheme", CommandType.StoredProcedure, param);
        }

        //用户列表
        public List<Themeinfo> GetUsers()
        {
            List<Themeinfo> list = new List<Themeinfo>();
            Themeinfo info = null;
            //SqlParameter[] parm = new SqlParameter[]
            //{
            //    //new SqlParameter("@ProductId",productId)
            //};
            using (SqlDataReader dr = Helper.ExecuteReader("GetUsers", CommandType.StoredProcedure, null))
            {
                while (dr.Read())
                {
                    info = new Themeinfo();

                    info.UserName = dr["UserName"].ToString();
                    info.Counts = Convert.ToInt32(dr["Counts"]); //== DBNull.Value ? 0 : Convert.ToInt32(dr["Counts"]);
                    list.Add(info);


                }
            }
            return list;
        }
        //发表文章
        public Boolean Insert_Article(Themeinfo info)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                //new SqlParameter("@ThemeId",info.ThemeId),
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@T_PublishTime",info.T_PublishTime),
                new SqlParameter("@T_Content",info.T_Content),
                new SqlParameter("@Spot",info.Spot)
            };
            return Helper.ExecuteNonQuery("Theme_InsertArticle", CommandType.StoredProcedure, parm);
        }

        //获取用户发表文章
        //public IList<Themeinfo> GetModelById(int userId)
        //{
        //    //List<Themeinfo> list = new List<Themeinfo>();
        //    //Themeinfo info = null;
        //    SqlParameter[] parm = new SqlParameter[]
        //    {
        //        new SqlParameter("@author", userId)
        //    };
        //    return Helper.GetDataSet("GetUserAllArticles", CommandType.StoredProcedure, parm);


        //}
        public IList<Themeinfo> GetUserAllArticles(int userId)
        {
            string sqlAll = "SELECT * FROM Theme where ThemeId=@author";


            return GetArticlesBySql(sqlAll, new SqlParameter("@author", userId));
        }

        private IList<Themeinfo> GetArticlesBySql(string sql, params SqlParameter[] values)
        {
            UserSerice ui = new UserSerice();
            List<Themeinfo> list = new List<Themeinfo>();
            DataTable table = Helper.GetDataSet(sql, values);
            foreach (DataRow row in table.Rows)
            {
                Themeinfo article = new Themeinfo();

                article.Id = (int)row["Id"];
                article.Title = (string)row["Title"];
                article.T_Content = (string)row["T_Content"];
                article.T_PublishTime = (DateTime)row["T_PublishTime"];
                article.Spot = (int)row["Spot"];
                article.Anthor = ui.GetUserById((int)row["Id"]); //FK
                list.Add(article);
            }
            return list;
        }
        public Themeinfo GetArticleById(int id)
        {
            UserSerice us = new UserSerice();
            string sql = "SELECT * FROM Theme WHERE Id = @Id";
            int ThemeId;
            SqlDataReader reader = Helper.GetReader(sql, new SqlParameter("@Id", id));
            if (reader.Read())
            {
                Themeinfo article = new Themeinfo();
                article.Id = (int)reader["Id"];
                article.Title = (string)reader["Title"];
                article.T_Content = (string)reader["T_Content"];
                article.T_PublishTime = (DateTime)reader["T_PublishTime"];
                article.Counts = (int)reader["Counts"];
                ThemeId = (int)reader["ThemeId"]; //FK
                reader.Close();
                article.Anthor = us.GetUserById(ThemeId);
                return article;
            }
            else
            {
                reader.Close();
                return null;
            }

        }

        //排序主题
        public List<Themeinfo> GetListByCon(string keys)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@keys",keys )
            };
            List<Themeinfo> list = new List<Themeinfo>();
            Themeinfo info = null;
            using (SqlDataReader rd = Helper.ExecuteReader("Theme_GetListByCon", CommandType.StoredProcedure, param))
            {
                while (rd.Read())
                {
                    info = new Themeinfo();
                    //info.Id = (int)rd["Id"];
                    info.ThemeId = (int)rd["ThemeId"];
                    info.Title = (string)rd["Title"];
                    info.UserId = (string)rd["UserId"];
                    info.T_PublishTime = (DateTime)rd["T_PublishTime"];
                    info.T_Content = (string)rd["T_Content"];
                    info.Spot = (int)rd["Spot"];
                    list.Add(info);
                }
            }
            return list;
        }

        //添加点击数
        public int AddClick(int ThemeId)
        {

            SqlParameter[] paras = new SqlParameter[]
            {
               new SqlParameter("@ThemeId",ThemeId),              
           };
            object obj = Helper.ExecuteScalar("AddClick", CommandType.StoredProcedure, paras);
            if (obj == null)
                return 0;
            return Convert.ToInt32(obj);

        }
        //获取对应的ID评论
        public List<Questions> GetModelById(int ThemeId)
        {
            List<Questions> list = new List<Questions>();
            Questions info = null;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ThemeId",ThemeId)
            };
            using (SqlDataReader rd = Helper.ExecuteReader("GetComById", CommandType.StoredProcedure, param))
            {
                while (rd.Read())
                {
                    info = new Questions(rd.GetString(0), rd.GetDateTime(1), rd.GetString(2));
                    list.Add(info);
                }
            }
            return list;
        }

        //获取对应文章
        public List<Themeinfo> GetListById(string ThemeId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ThemeId",ThemeId )
            };
            List<Themeinfo> list = new List<Themeinfo>();
            Themeinfo info = null;
            using (SqlDataReader rd = Helper.ExecuteReader("Theme_GetList", CommandType.StoredProcedure, param))
            {
                while (rd.Read())
                {
                    info = new Themeinfo();
                    //info.Id = (int)rd["Id"];
                 
                    info.Title = (string)rd["Title"];
                    info.UserId = (string)rd["UserId"];
                    info.T_PublishTime = (DateTime)rd["T_PublishTime"];
                    info.T_Content = (string)rd["T_Content"];
                    info.Spot = (int)rd["Spot"];
                    list.Add(info);
                }
            }
            return list;
        }
    }
}
