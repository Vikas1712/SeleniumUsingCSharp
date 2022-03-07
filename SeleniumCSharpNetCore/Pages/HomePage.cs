using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class HomePage:DriverHelper
    {
        IWebElement signIn => Driver.FindElement(By.XPath("//a[normalize-space()='Sign in']"));

        public void ClickSignIn() => signIn.Click();
    }
}
