using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class Userinfo
    {

        public Userinfo()
        {
            Id = 0;
            UserId = string.Empty;
            Pwd = string.Empty;
            NickName = string.Empty;
            Email = string.Empty;
            QQ = string.Empty;
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string  _UserId;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _Pwd;

        public string Pwd
        {
            get { return _Pwd; }
            set { _Pwd = value; }
        }

        private string _NickName;

        public string NickName
        {
            get { return _NickName; }
            set { _NickName = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _QQ;

        public string QQ
        {
            get { return _QQ; }
            set { _QQ = value; }
        }
        private int _Counts;

        public int Counts
        {
            get { return _Counts; }
            set { _Counts = value; }
        }



     
    }
}
