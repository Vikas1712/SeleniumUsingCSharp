namespace SeleniumCSharpNetCore.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private WaitActionPage _waitActions;
        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
            _waitActions = new WaitActionPage(driver);
        }
        private readonly By linkSignIn = By.CssSelector("a[title='Log in to your customer account']");
        public void ClickSignIn()
        {
            _waitActions.WaitForPageToLoaded();
            _waitActions.WaitForElementClickable(linkSignIn);
            Thread.Sleep(5000);
            _waitActions.ClickElement(linkSignIn);
        }
        public void OpenAutomationPracticeSite()
        {
            string url = "http://automationpractice.com";
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }
    }
}
