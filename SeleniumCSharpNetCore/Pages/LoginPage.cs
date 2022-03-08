using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }
        IWebElement txtEmailAddress => _driver.FindElement(By.CssSelector("#email"));
        IWebElement txtPassword => _driver.FindElement(By.CssSelector("#passwd"));
        IWebElement btnSubmitLogin => _driver.FindElement(By.CssSelector("#page"));

        public void EnterUserNameAndPassword(string username, string password)
        {
            txtEmailAddress.SendKeys(username);
            txtPassword.SendKeys(password);
        }
        
        public void ClickSignIn()
        {
            btnSubmitLogin.Click();
        }
    }
}
