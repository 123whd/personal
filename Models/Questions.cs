using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class Questions
    {

        public Questions(string R_Content, DateTime R_PublishTime, string Author)
        {
            this.R_Content = R_Content;
            this.R_PublishTime = R_PublishTime;
            this.Author = Author;
        }

        private int _ThemeId;

        public int ThemeId
        {
            get { return _ThemeId; }
            set { _ThemeId = value; }
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private Themeinfo article;

        public Themeinfo Article
        {
            get { return article; }
            set { article = value; }
        }
        private string _Author = String.Empty;

        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        private string _R_Content = String.Empty;

        public string R_Content
        {
            get { return _R_Content; }
            set { _R_Content = value; }
        }
        private DateTime _R_PublishTime;

        public DateTime R_PublishTime
        {
            get { return _R_PublishTime; }
            set { _R_PublishTime = value; }
        }



        public Questions()
        {
            article = new Themeinfo();
        }



       
    }
}
