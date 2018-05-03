using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBHelper;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public static class CommentService
    {
        public static int GetCommentNumber(int ThemeId)
        {
            string sql = "SELECT count(*) FROM T_Content WHERE ThemeId = @ThemeId";
            int commentNumber;
            try
            {
                commentNumber = Helper.GetScalar(sql, new SqlParameter("@ThemeId", ThemeId));
                return commentNumber;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static IList<Questions> GetCommentByArticleId(int ThemeId)
        {
            string sqlAll = "SELECT * FROM Theme WHERE ThemeId = @ThemeId";
            return GetCommentsBySql(sqlAll, new SqlParameter("@ThemeId", ThemeId));
        }

        private static IList<Questions> GetCommentsBySql(string sql, params SqlParameter[] values)
        {
            Themeservice tm = new Themeservice();
            List<Questions> list = new List<Questions>();
            DataTable table = Helper.GetDataSet(sql, values);
            foreach (DataRow row in table.Rows)
            {
                Questions comment = new Questions();
                comment.Id = (int)row["Id"];
                comment.Author = (string)row["Author"];
                comment.R_Content = (string)row["R_Content"];
                comment.R_PublishTime = (DateTime)row["R_PublishTime"];
                comment.Article = tm.GetArticleById((int)row["ThemeId"]); //FK
                list.Add(comment);
            }
            return list;
        }

        //添加评论
        public static void AddComment(Questions qs)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
               
               new SqlParameter("@id",qs.ThemeId),
               new SqlParameter("@Author",qs.Author),
               new SqlParameter("@R_Content",qs.R_Content),
               new SqlParameter("@R_PublishTime",qs.R_PublishTime)            
           };
            Helper.ExecuteScalar("AddComment", CommandType.StoredProcedure, paras);
        }

        
    }
}
