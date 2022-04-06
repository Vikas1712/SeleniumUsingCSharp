using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }
        IWebElement SignIn => _driver.FindElement(By.LinkText("Sign in"));

        public void ClickSignIn() => SignIn.Click();
    }
}
