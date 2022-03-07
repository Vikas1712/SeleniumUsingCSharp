using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
namespace SeleniumCSharpNetCore
{
    public class Tests
    {
        public IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Set up");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            _webDriver.Navigate().GoToUrl("http://automationpractice.com");
            _webDriver.Manage().Window.Maximize();

            IWebElement signIn = _webDriver.FindElement(By.XPath("//a[normalize-space()='Sign in']"));
            signIn.Click();
            
            IWebElement emailAddress = _webDriver.FindElement(By.XPath("//input[@id='email']"));
            //fluentWait.Until(x => x.FindElement(By.XPath(target_xpath)));
            waitForElementToLoad(emailAddress);

            emailAddress.SendKeys("dnsvikas.wins@gmail.com");

            IWebElement password = _webDriver.FindElement(By.XPath("//input[@id='passwd']"));
            password.SendKeys("Password");

            IWebElement submitLogin = _webDriver.FindElement(By.XPath("//span[normalize-space()='Sign in']"));
            submitLogin.Click();

            IWebElement signOut = _webDriver.FindElement(By.XPath("//a[@title='Log me out']"));
            waitForElementToLoad(signOut);

            Console.WriteLine("Pass");
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        public static IWebElement waitForElementToLoad(IWebElement element)
        {
            DefaultWait<IWebElement> fluentWait = new DefaultWait<IWebElement>(element);
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            fluentWait.Timeout = TimeSpan.FromMinutes(2);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);


            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                if (element.Displayed)
                {
                    Console.WriteLine("Element is Displayed" + element);
                    return true;
                }
                return false;
            });
            fluentWait.Until(waiter);
            return element;
        }
    }
}