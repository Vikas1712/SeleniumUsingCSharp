using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage:DriverHelper
    {
        IWebElement txtEmailAddress => Driver.FindElement(By.XPath("//input[@id='email']"));

        IWebElement txtPassword => Driver.FindElement(By.XPath("//input[@id='passwd']"));

        IWebElement btnSubmitLogin => Driver.FindElement(By.XPath("//span[normalize-space()='Sign in']"));

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
