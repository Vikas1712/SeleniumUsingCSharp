namespace SeleniumCSharpNetCore.Config
{
    public class Settings
    {
        public static string IsReport { get; set; }
        public static string TestType { get; set; }
        public static string AUT { get; set; }
        public static string BuildName { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string IsLog { get; set; }
        public static int DefaultWait { get; set; }
    }
}