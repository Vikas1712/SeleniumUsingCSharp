namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage : BasePage
    {
        private IWebElement TxtEmailAddress => DriverContext.Driver.FindElement(By.CssSelector("#email"));
        private IWebElement TxtPassword => DriverContext.Driver.FindElement(By.CssSelector("#passwd"));
        private IWebElement BtnSubmitLogin => DriverContext.Driver.FindElement(By.CssSelector("#SubmitLogin"));

        public ProductPage ClickSubmitLogin()
        {
            DriverContext.Driver.WaitForPageToLoaded();
            BtnSubmitLogin.ClickElement();
            return GetInstance<ProductPage>();
        }

        public void RegisterUserNameAndPassword()
        {
            TxtEmailAddress.SendKeys(Settings.UserName);
            TxtPassword.SendKeys(Settings.Password);
        }
    }
}