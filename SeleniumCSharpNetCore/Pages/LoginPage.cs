namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage:BasePage
    {
        public WaitActionPage _waitActions = new WaitActionPage();
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
            DriverContext.Driver.FindElement(txtEmailAddress).SendKeys("dnsvikas.wins@gmail.com");
            DriverContext.Driver.FindElement(txtPassword).SendKeys("Password");
        }
    }
}
