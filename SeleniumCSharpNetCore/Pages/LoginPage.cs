using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private WaitActionPage _waitActions;
        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            _waitActions = new WaitActionPage(driver);
        }
        private readonly By txtEmailAddress = By.CssSelector("#email");
        private readonly By txtPassword = By.CssSelector("#passwd");
        private readonly By btnSubmitLogin = By.CssSelector("#SubmitLogin");
        public void ClickSubmitLogin()
        {
            _waitActions.WaitForPageToLoaded();
            _waitActions.ClickElement(btnSubmitLogin);
        }
        public void RegisterUserNameAndPassword()
        {
            _driver.FindElement(txtEmailAddress).SendKeys("dnsvikas.wins@gmail.com");
            _driver.FindElement(txtPassword).SendKeys("Password");
        }
    }
}
