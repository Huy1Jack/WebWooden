using Newtonsoft.Json;
using System.Text.Json;

namespace WebWooden.Helpes
{
    public static class SessionExtensions
    {
        // Extension method để lưu đối tượng vào session
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Extension method để lấy đối tượng từ session
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

    }
}
