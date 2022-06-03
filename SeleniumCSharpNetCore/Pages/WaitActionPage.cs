using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using System.Linq;

namespace SeleniumCSharpNetCore.Pages
{
	public class WaitActionPage
	{
		private IWebDriver _driver;
		private const int DefaultWait = 30;

		public WaitActionPage(IWebDriver webDriver)
		{
			_driver = webDriver;
		}
		public IWebElement WaitForElementClickable(IWebElement element)
		{
			WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWait));
			var matchingElement = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
			//identify element then obtain text
			if (matchingElement == null)
			{
				Assert.Fail("Element hasn't become clickable in the provided time");
			}

			return matchingElement;
		}

		public IWebElement WaitForElementClickable(By locator)
		{
			WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWait));
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
			WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWait));
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
			WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWait));
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
			IWebElement iframe = _driver.FindElement(By.TagName("iframe"));
			_driver.SwitchTo().Frame(iframe);
		}
	}
}
