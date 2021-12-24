namespace _7DaysToDieUtils.Const
{
    internal class Config
    {

        public readonly static bool IS_DEBUG = false;

        public readonly static string BASE_URL_LOCAL = "http://localhost:7777";

        public readonly static string BASE_URL = "http://47.100.54.71:7777";

        public static string GetBaseUrl()
        {
            if (IS_DEBUG)
            {
                return BASE_URL_LOCAL;
            }
            else
            {
                return BASE_URL;
            }
        }

        public static string TOKEN = "";

    }
}
