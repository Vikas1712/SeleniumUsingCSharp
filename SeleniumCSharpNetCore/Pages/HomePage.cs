namespace SeleniumCSharpNetCore.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement LinkSignIn => DriverContext.Driver.FindElement(By.CssSelector("a[title='Log in to your customer account']"));

        public LoginPage ClickSignIn()
        {
            DriverContext.Driver.WaitForPageToLoaded();
            Thread.Sleep(5000);
            LinkSignIn.ClickElement();
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