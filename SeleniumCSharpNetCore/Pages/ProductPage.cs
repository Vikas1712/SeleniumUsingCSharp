using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpNetCore.Pages
{
    public class ProductPage
    {
        private IWebDriver _driver;
        public ProductPage(IWebDriver driver)
        {
            this._driver = driver;
        }
        IWebElement productCategoryLocator => _driver.FindElement(By.CssSelector("a[title='T-shirts']"));

        public void SelectProductCategory()
        {
            _driver.FindElement(By.CssSelector("a[title='Women']")).Click(); ;

        }

        public void SelectProduct()
        {

        }
    }
}
