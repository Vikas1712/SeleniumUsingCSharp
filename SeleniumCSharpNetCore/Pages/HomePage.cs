namespace SeleniumCSharpNetCore.Pages
{
    public class HomePage : BasePage
    {
        public WaitActionPage _waitActions = new WaitActionPage();
        private readonly By linkSignIn = By.CssSelector("a[title='Log in to your customer account']");
        public LoginPage ClickSignIn()
        {
            //_waitActions.WaitForPageToLoaded();
            DriverContext.Driver.WaitForPageToLoaded();
            _waitActions.WaitForElementClickable(linkSignIn);
            Thread.Sleep(5000);
            _waitActions.ClickElement(linkSignIn);
            return GetInstance<LoginPage>();
        }
        public ProductPage OpenAutomationPracticeSite()
        {
            DriverContext.Driver.Navigate().GoToUrl(Settings.AUT);
            DriverContext.Driver.Manage().Window.Maximize();
            return GetInstance<ProductPage>();
        }
    }
}
