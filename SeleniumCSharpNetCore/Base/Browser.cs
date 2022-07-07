namespace SeleniumCSharpNetCore.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;   
        }
        public Browser Type { get; set; }

    }
    public enum BrowserType
    {
        Edge,
        FireFox,
        Chrome,
        Opera
    }
}
