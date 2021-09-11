using dronesIL.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace helpers.SessionHelper
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public static bool IsUserConnected(this ISession session)
        {
            if(session.GetString("user")!=null)
            {
                return true;
            }
            return false;
        }
        public static string GetStringFromSession(this ISession session, string key)
        {
            return session.GetString(key);
        }
    }
}