using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

/// <summary>
///CommonHandler 的摘要说明
/// </summary>
public static class CommonHandler
{
    //public  CommonHandler()
    //{
    //    //
    //    //TODO: 在此处添加构造函数逻辑
    //    //
    //}
         /// <summary>
    /// 截断字符串
    /// </summary>
    /// <param name="content"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string CutString(string content, int num)
    {
        if (content.ToString().Length > num - 2)
            return content.ToString().Substring(0, num - 2) + "...";
        else
            return content.ToString();
    }

    /// <summary>
    /// 获得评论总数
    /// </summary>
    /// <param name="ArticleId"></param>
    /// <returns></returns>
    public static int GetCommentNumber(int ThemeId)
    {
        //CommentManager cm = new CommentManager();
        return CommentManager.GetCommentNumber(ThemeId);
    }

	
}