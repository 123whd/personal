using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
using DAL;


namespace BLL
{ 
    
    public class ThemeManager
    {

        Themeservice th = new Themeservice();
        //热门文章

        public int AddClick(int ThemeId)
        {
            
            return th.AddClick(ThemeId);
        }
        public List<Themeinfo> GetModelById()
        {
          
            return th.GetModelById();
        }
        //主题内容
        public List<Themeinfo> GetTheme()
        {

            return th.GetTheme();
        }
        //用户列表
        public List<Themeinfo> GetUsers()
        {

            return th.GetUsers();
        }
        //发表文章
        public Boolean Insert_Article(Themeinfo info)
        {
            return th.Insert_Article(info);
        }

        public  IList<Themeinfo> GetArticleByUserId(int userid)
        {
            return th .GetUserAllArticles(userid);
        }

        public List<Themeinfo> GetListByCon(string keys)
        {
            return th.GetListByCon(keys);
        }
        //获取相应的ID主题
        public List<Questions> GetModelById(int ThemeId)
        {

            return th.GetModelById(ThemeId);
        }
        //获取对应文章
        public List<Themeinfo> GetListById(string ThemeId)
        {
            return th.GetListById(ThemeId);
        }

        //删除文章
        public bool DeleteTheme(int themeId)
        {
            return th.DeleteTheme(themeId);
        }

        /// 修改文章
        public bool UpdateTheme(Themeinfo info)
        {
            return th.UpdateTheme(info);
        }
    }
}
