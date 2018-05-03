using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class Themeinfo
    {

        public Themeinfo()
        {
            Id = 0;
            anthor = new Userinfo();
            ThemeId = 0;
            UserId = string.Empty;
            Title = string.Empty;
            T_PublishTime = DateTime.Now;
            T_Content = string.Empty;
            Spot = 0;
        }
        public Themeinfo(string T_Content, DateTime T_PublishTime, string UserId)
        {
            this.T_Content = T_Content;
            this.T_PublishTime = T_PublishTime;
            this.UserId = UserId;
        }

        private Userinfo anthor;

        public Userinfo Anthor
        {
            get { return anthor; }
            set { anthor = value; }
        }
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _ThemeId;

        public int ThemeId
        {
            get { return _ThemeId; }
            set { _ThemeId = value; }
        }
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }



        private string _UserId;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        private DateTime _T_PublishTime;

        public DateTime T_PublishTime
        {
            get { return _T_PublishTime; }
            set { _T_PublishTime = value; }
        }
        private string _T_Content;

        public string T_Content
        {
            get { return _T_Content; }
            set { _T_Content = value; }
        }
        private int _Spot;

        public int Spot
        {
            get { return _Spot; }
            set { _Spot = value; }
        }
        private bool _Vis;

        public bool Vis
        {
            get { return _Vis; }
            set { _Vis = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private int _Counts;

        public int Counts
        {
            get { return _Counts; }
            set { _Counts = value; }
        }
   
    }
}
