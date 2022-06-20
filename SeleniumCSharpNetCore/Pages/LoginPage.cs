﻿using OpenQA.Selenium;

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
        public void EnterUserNameAndPassword(string username, string password)
        {
            _driver.FindElement(txtEmailAddress).SendKeys(username);
            _driver.FindElement(txtPassword).SendKeys(password);
        }
        
        public void ClickSubmitLogin()
        {
            _waitActions.WaitForElementClickable(btnSubmitLogin);
            _waitActions.ClickElement(btnSubmitLogin);
        }

        public void registerUserNameAndPassword()
        {
            _driver.FindElement(txtEmailAddress).SendKeys("dnsvikas.wins@gmail.com");
            _driver.FindElement(txtPassword).SendKeys("Password");
        }
    }
}
