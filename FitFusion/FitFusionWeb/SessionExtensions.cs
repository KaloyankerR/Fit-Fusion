using Microsoft.AspNetCore.Http;

public static class SessionExtensions
{
    public static void SetBool(this ISession session, string key, bool value)
    {
        session.SetString(key, value.ToString());
    }

    public static bool GetBool(this ISession session, string key)
    {
        string? value = session.GetString(key);
        return value != null && bool.TryParse(value, out bool result) ? result : false;
    }
}
