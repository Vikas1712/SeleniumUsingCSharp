using OpenQA.Selenium;
using System;
namespace SeleniumCSharpNetCore.Base
{
    public static class DriverContext
    {

        private static IWebDriver _driver;
        public static IWebDriver Driver { get { return _driver; } set { _driver = value; } }

        public static Browser Browser { get; set; }

        public static MediaEntityModelProvider CaptureScreenShot(string screenShotName)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}
