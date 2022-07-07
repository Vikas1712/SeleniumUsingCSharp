//We try to pass the WebDriver object over and over again from one class to another
//by the mean of constructor or passing it as a parameter in the method where driver isntance is required
//Hence we created a static base class and created a static property

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
