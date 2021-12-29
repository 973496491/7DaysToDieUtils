namespace _7DaysToDieUtils.Cache
{
    public class UserInfo
    {
        private UserInfo() { }

        private static UserInfo instance;

        public static UserInfo GetInstance()
        {
            if (instance == null)
            {
                instance = new UserInfo();
            }
            return instance;
        }

        public string UserName { get; set; }

        public string GamePath { get; set; }

        public int FastDownloadCount { get; set; }

        public bool IsAdmin { get; set; }
    }
}
