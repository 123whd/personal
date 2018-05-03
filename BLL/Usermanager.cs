using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;


namespace BLL
{
    public  class Usermanager
    {
        //判断注册
        public  bool Register(Userinfo user)
        {
            if (LoginIdExists(user.UserId))
            {
                return false;
            }
            else
            {
                AddUser(user);
                return true;
            }
        }
        UserSerice us = new UserSerice();
        public bool LoginIdExists(string UserId)
        {
            return us.GetUserByLoginId(UserId);
        }

        //注册
        public void AddUser(Userinfo user)
        {
             us.Add_Users(user);
        }

        public bool Login(string UserId, string loginPwd, out Userinfo validUser)
        {
            UserSerice us = new UserSerice();
            Userinfo user = us.GetUserById(UserId);
            if (user == null)
            {
                //用户名不存在 
                validUser = null;
                return false;
            }
            if (user.Pwd == loginPwd)
            {
                validUser = user;
                return true;
            }
            else
            {
                //密码错误
                validUser = null;
                return false;
            }
        }
    }
}
