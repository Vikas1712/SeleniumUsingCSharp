namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage:BasePage
    {
        public WaitActionPage _waitActions = new WaitActionPage();
        private readonly By txtEmailAddress = By.CssSelector("#email");
        private readonly By txtPassword = By.CssSelector("#passwd");
        private readonly By btnSubmitLogin = By.CssSelector("#SubmitLogin");
        public ProductPage ClickSubmitLogin()
        {
            DriverContext.Driver.WaitForPageToLoaded();
            _waitActions.ClickElement(btnSubmitLogin);
            return GetInstance<ProductPage>();
        }
        public void RegisterUserNameAndPassword()
        {
            DriverContext.Driver.FindElement(txtEmailAddress).SendKeys(Settings.UserName);
            DriverContext.Driver.FindElement(txtPassword).SendKeys(Settings.Password);
        }
    }
}
