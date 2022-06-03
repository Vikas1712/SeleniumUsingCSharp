using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SeleniumCSharpNetCore.Pages
{
    public class ProductPage
    {
        private IWebDriver _driver;
        private WaitActionPage _waitActions;
        public ProductPage(IWebDriver driver)
        {
            this._driver = driver;
            _waitActions = new WaitActionPage(driver);
        }
        private readonly By dropDownWomenProductCategory = By.CssSelector("a[title='Women']");
        private readonly By imgProductIcon = By.CssSelector("img[title='Faded Short Sleeve T-shirts']");
        private readonly By txtProductDescription = By.Id("short_description_block");
        private readonly By btnAddToCart = By.Id("add_to_cart");
        private readonly By checkBoxProductCategory = By.CssSelector("label[for='layered_category_4']");

        public void SelectProductCategory()
        {
            _waitActions.WaitForElementClickable(dropDownWomenProductCategory);
            _waitActions.ClickElement(dropDownWomenProductCategory);
        }

        public void SelectProduct()
        {
            _waitActions.WaitForElementClickable(imgProductIcon);
            _waitActions.ClickElement(imgProductIcon);
        }

        public void ViewProductDetail()
        {
            _waitActions.SwitchToIFrame();
            _waitActions.WaitForElementDisplayed(btnAddToCart);
            _waitActions.WaitForElementDisplayed(txtProductDescription);
            _driver.SwitchTo().DefaultContent();
        }

        public int CountNumberOfProducts()
        {
            var list = _driver.FindElement(By.ClassName("product_list"));
            int listItems = list.FindElements(By.TagName("li")).Count();
            return listItems;
        }

        public void SetFilterBasedOnCategory()
        {
            _waitActions.WaitForElementClickable(checkBoxProductCategory);
            _waitActions.ClickElement(checkBoxProductCategory);
            Thread.Sleep(5000);
        }
    }
}
