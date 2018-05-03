using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace BLL
{
    public static class CommentManager
    {
        //CommentService cs = new CommentService();
        public static int GetCommentNumber(int ThemeId)
        {
            return CommentService.GetCommentNumber(ThemeId);
        }

        public static IList<Questions> GetCommentByArticleId(int ThemeId)
        {
            return CommentService.GetCommentByArticleId(ThemeId);
        }

        public static void AddComment(Questions qs)
        {
             CommentService.AddComment(qs);
        }
    }
}
