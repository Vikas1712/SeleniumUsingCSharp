namespace SeleniumCSharpNetCore.Pages
{
    public class DriverHelper
    {
        public IWebDriver Driver { get; set; }
        public MediaEntityModelProvider CaptureScreenShot(string screenShotName)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}