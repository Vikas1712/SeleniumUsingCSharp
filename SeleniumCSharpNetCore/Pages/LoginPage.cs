using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }
        IWebElement TxtEmailAddress => _driver.FindElement(By.CssSelector("#email"));
        IWebElement TxtPassword => _driver.FindElement(By.CssSelector("#passwd"));
        IWebElement BtnSubmitLogin => _driver.FindElement(By.CssSelector("#page"));

        public void EnterUserNameAndPassword(string username, string password)
        {
            TxtEmailAddress.SendKeys(username);
            TxtPassword.SendKeys(password);
        }
        
        public void ClickSignIn()
        {
            BtnSubmitLogin.Click();
        }

        public void OpenAutomationPracticeSite()
        {
            string url = "http://automationpractice.com";
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }
    }
}
