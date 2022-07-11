using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumCSharpNetCore.Extensions
{
    public static class WebElementExtension
    {
        public static void SelectDDL(this IWebElement element, string value)
        {
            SelectElement ddl = new(element);
            ddl.SelectByText(value);
        }

        public static string GetText(IWebElement element)
        {
            return element.Text;
        }

        public static string GetSelectedDropDown(IWebElement element)
        {
            SelectElement ddl = new(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(IWebElement element)
        {
            SelectElement ddl = new(element);
            return ddl.AllSelectedOptions;
        }

        /// <summary>
        /// Check if the element exist
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool b = element.IsDisplayed();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDisplayed(this IWebElement element)
        {
            bool result;
            try
            {
                result = element.Displayed;
            }
            catch (Exception)
            {
                result = false;
            }
            // Log the Action
            return result;
        }

        /// <summary>
        /// Assert if the Element is present
        /// </summary>
        /// <param name="element"></param>
        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new AssertionException(String.Format("AssertElementNotPresent exception"));
        }

        public static IWebElement WaitForElementClickable(this IWebElement element)
        {
            WebDriverWait w = new(DriverContext.Driver, TimeSpan.FromSeconds(Settings.DefaultWait));
            var matchingElement = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            //identify element then obtain text
            if (matchingElement == null)
            {
                Assert.Fail("Element hasn't become clickable in the provided time");
            }
            return matchingElement;
        }

        public static IWebElement ClickElement(this IWebElement locator)
        {
            var element = WaitForElementClickable(locator);
            element.Click();
            return element;
        }
    }
}