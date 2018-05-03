using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Answersserice
    {
        //添加信息
    //    public void insert_Answers_Options(Answers Suy)
    //    {
    //        SqlParameter[] paras = new SqlParameter[]{
    //           new SqlParameter("@Title",Suy.Title),
    //           new SqlParameter("@StateTime",Suy.StateTime),
    //           new SqlParameter("@EndTime",Suy.EndTime),          
    //       };
    //        object obj = Helper.ExecuteScalar("Answers_Insert", CommandType.StoredProcedure, paras);
    //        if (obj != null)
    //        {
    //            int Suid = Convert.ToInt32(obj);
    //            SqlParameter[] param = new SqlParameter[]
    //          {
    //              new SqlParameter ("@Suid",SqlDbType.Int,4),
    //              new SqlParameter ("@Number",SqlDbType.Int,4),
    //              new SqlParameter ("@Name",SqlDbType.VarChar,100)
    //          };
    //            param[0].Value = Suid;

    //        }
    //    }
    }
}
