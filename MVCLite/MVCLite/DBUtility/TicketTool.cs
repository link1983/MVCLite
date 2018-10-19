/*###################票据工具###################
 * 1.设置<authentication mode="Forms"/>
 * 2.票据数据保存在cookie中，Logout就一直处于登录状态。
 ##############################################*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;

namespace MVCLite.DBUtility
{
    public class TicketTool
    {
        /// <summary>
        /// 创建一个票据，放在cookie中
        /// 票据中的数据经过加密，解决了cookie的安全问题。
        /// </summary>
        /// <param name="username"></param>
        public static void SetCookie(string username, string userData)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(60), false, userData, FormsAuthentication.FormsCookiePath);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie newCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(newCookie);
        }
        /// <summary>
        /// 通过此法判断登录
        /// </summary>
        /// <returns>已登录返回true</returns>
        public static bool IsLogin()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
        /// <summary>
        /// 取得登录用户名
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            return HttpContext.Current.User.Identity.Name;
        }
        /// <summary>
        /// 取得票据中数据
        /// </summary>
        /// <returns></returns>
        public static string GetUserData()
        {
            return (HttpContext.Current.User.Identity as FormsIdentity).Ticket.UserData;
        }
    }
}