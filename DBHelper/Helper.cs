using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBHelper
{
    public abstract class Helper
    {
        //数据库连接字符串
        private static readonly string str = ConfigurationManager.ConnectionStrings["data"].ConnectionString;
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmd"></param>
        /// <param name="Text"></param>
        /// <param name="cmdType"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string Text, CommandType cmdType, SqlParameter[] parm)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            //调用公共方法
            ProCommand(conn, cmd, Text, cmdType, parm);
            bool b = false;
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                b = true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return b;
        }
        /// <summary>
        /// 执行命令返回第一行第一列
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmd"></param>
        /// <param name="Text"></param>
        /// <param name="cmdType"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string Text, CommandType cmdType, SqlParameter[] parm)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            ProCommand(conn, cmd, Text, cmdType, parm);
            object obj = null;
            try
            {
                obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return obj;
        }

        public static SqlDataReader ExecuteReader(string Text, CommandType cmdType, SqlParameter[] parm)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            ProCommand(conn, cmd, Text, cmdType, parm);

            SqlDataReader rd = null;
            try
            {
                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }



            return rd;


        }

        private static void ProCommand(SqlConnection conn, SqlCommand cmd, string Text, CommandType cmdType, SqlParameter[] parm)
        {
            conn.ConnectionString = str;//设置连接字符串
            if (conn.State == ConnectionState.Closed)//判断字符串是否打开
                conn.Open();
            cmd.Connection = conn;//命令与连接对象关联
            cmd.CommandText = Text;//设置文本
            cmd.CommandType = cmdType;//设置类型
            if (parm != null)
                cmd.Parameters.AddRange(parm);//添加参数集

        }

        //public static DataTable GetDataSet(string Text, CommandType cmdType, SqlParameter[] parm)
        //{
        ////    SqlConnection conn;
        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    DataSet ds = new DataSet();
        //    ProCommand(conn, cmd, Text, cmdType, parm);
        //    cmd.Parameters.AddRange(parm);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(ds);
        //    return ds.Tables[0];
        //}
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                //add by 51aspx
                //string connectionString = ConfigurationManager.AppSettings["data"];
                if (connection == null)
                {
                    connection = new SqlConnection(str);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
    }
}
