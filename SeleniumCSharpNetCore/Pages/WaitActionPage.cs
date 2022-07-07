using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace SeleniumCSharpNetCore.Pages
{
    public class WaitActionPage:BasePage
	{
		private const int DefaultWait = 90;
		public IWebElement WaitForElementClickable(By locator)
		{
			WebDriverWait w = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(DefaultWait));
			var matchingElement = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
			//identify element then obtain text
			if (matchingElement == null)
			{
				Assert.Fail("Element hasn't become clickable in the provided time");
			}
			return matchingElement;
		}
		public IWebElement WaitForElementDisplayed(By locator)
		{
			WebDriverWait w = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(DefaultWait));
			var matchingElement = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
			return matchingElement;
		}
		public IWebElement ClickElement(By by, string textToSearch = "")
		{
			var element = WaitForElementClickable(by, textToSearch);
			element.Click();
			return element;
		}
		internal IWebElement WaitForElementClickable(By locator, string textToSearch = "")
		{
			IWebElement matchingElement;
			WebDriverWait w = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(DefaultWait));
			if (string.IsNullOrEmpty(textToSearch))
			{
				matchingElement = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
			}
			else
			{
				matchingElement = w.Until(d =>
				{
					var elements = d.FindElements(locator);
					var element = elements.FirstOrDefault(el => el.Enabled && el.Displayed && el.Text.Equals(textToSearch));
					return element;
				});
			}
			if (matchingElement == null)
			{
				Assert.Fail("Element hasn't become clickable in the provided time-span");
			}
			return matchingElement;
		}
		public void SwitchToIFrame()
        {
			IWebElement iframe = DriverContext.Driver.FindElement(By.TagName("iframe"));
			DriverContext.Driver.SwitchTo().Frame(iframe);
		}
		//public void WaitForPageToLoaded()
		//{
		//	IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
		//	js.ExecuteScript("return document.readyState").ToString().Equals("complete");
		//}
	}
}
