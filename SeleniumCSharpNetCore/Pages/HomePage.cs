using OpenQA.Selenium;

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

        private readonly By linkSignIn = By.PartialLinkText("Sign");

        public void ClickSignIn()
        {
            _waitActions.WaitForPageToLoaded();
            _waitActions.WaitForElementClickable(linkSignIn);
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
