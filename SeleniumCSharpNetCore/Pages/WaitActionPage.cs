using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace SeleniumCSharpNetCore.Pages
{
    public class WaitActionPage
    {
		private IWebDriver _driver;
		public IWebElement WaitForElementClickable(IWebElement element)
		{
			WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
			var matchingElement = w.Until(ExpectedConditions.ElementToBeClickable(element));
			//identify element then obtain text
			if (matchingElement == null)
			{
				Assert.Fail("Element hasn't become clickable in the provided time");
			}

			return matchingElement;
		}

	}
}
