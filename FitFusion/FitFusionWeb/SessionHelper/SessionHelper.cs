using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FitFusionWeb.SessionHelper
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

        // Add an overload to handle Dictionary<T, int>
        public static void SetDictionaryAsJson<T>(this ISession session, string key, Dictionary<T, int> value)
        {
            session.SetObjectAsJson(key, value);
        }

        // Add an overload to handle Dictionary<T, int>
        public static Dictionary<T, int> GetDictionaryFromJson<T>(this ISession session, string key)
        {
            return session.GetObjectFromJson<Dictionary<T, int>>(key);
        }


    }
}
