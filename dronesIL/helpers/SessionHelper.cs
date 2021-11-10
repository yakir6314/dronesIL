using dronesIL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;

namespace helpers.SessionHelper
{
    public static class SessionHelper
    {
        public static void SetObjectAsJsonOnSession(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJsoFromSessionn<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public static void connectUser(this user user, ISession session)
        {
            try
            {
                SetObjectAsJsonOnSession(session, "user", user);
            }
            catch(Exception up)
            {
                throw up;
            }
        }
        public static void DisconnectUser(ISession session)
        {
            try
            {
                SetObjectAsJsonOnSession(session, "user", null);
            }
            catch (Exception up)
            {
                throw up;
            }
        }
        public static bool IsUserConnected(this ISession session)
        {
            if(session.GetString("user")!=null)
            {
                return true;
            }
            return false;
        }
        public static bool isUserAdmin(this ISession session)
        {
            bool response = false;
            if (session.GetString("user") != null)
            {
                string userJson = session.GetString("user");
                user user = JsonConvert.DeserializeObject<user>(userJson);
                if (user.isAdmin == true)
                {
                    response = true;
                }
            }
            return response;
        }
        public static string GetStringFromSession(this ISession session, string key)
        {
            return session.GetString(key);
        }
    }
    public class RequireAuthenticationAttribute: ActionFilterAttribute
    {
        private bool isNeedAdmin { get; set; }
        public RequireAuthenticationAttribute(bool isAdmin)
        {
            this.isNeedAdmin = isAdmin;
        }
        public RequireAuthenticationAttribute()
        {
            this.isNeedAdmin = false;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (this.isNeedAdmin)
            {
                if (!SessionHelper.isUserAdmin(filterContext.HttpContext.Session))
                {
                    filterContext.Result = new RedirectResult(string.Format("/Home/unAutorized"));
                }
            }
            else
            {
                if (!SessionHelper.IsUserConnected(filterContext.HttpContext.Session))
                {
                    filterContext.Result = new RedirectResult(string.Format("/Home/unAutorized"));
                }
            }

        }
    }
}