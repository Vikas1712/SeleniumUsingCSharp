﻿using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class CartPage
    {
        
        private IWebDriver _driver;
        private WaitActionPage _waitActions;
        public CartPage(IWebDriver driver)
        {
            this._driver = driver;
            _waitActions = new WaitActionPage(driver);
        }

        private readonly By txtProductAddedSuccessfully = By.CssSelector("div[class='layer_cart_product col-xs-12 col-md-6'] h2");
        private readonly By btnProceedToCheckout = By.CssSelector("a[title='Proceed to checkout'] span");
        private readonly By btnContinueShopping = By.CssSelector("span[title='Continue shopping'] span:nth-child(1)");
        private readonly By txtShoppingHeader = By.CssSelector("#summary_products_quantity");
        private readonly By btnRemoveCartDelete = By.CssSelector("td[class='cart_delete text-center'] div");
        private readonly By txtCartIsEmpty = By.CssSelector(".alert.alert-warning");
        
        public void SelectProceedToCheckout()
        {
            _waitActions.WaitForElementClickable(btnProceedToCheckout);
            _waitActions.ClickElement(btnProceedToCheckout);
        }

        public void SelectContinueToShopping()
        {
            _waitActions.WaitForElementClickable(btnContinueShopping);
            _waitActions.ClickElement(btnContinueShopping);
        }
        public void ViewCartDetail()
        {
            _waitActions.WaitForElementDisplayed(txtProductAddedSuccessfully);
        }
        
        public void VerifyCardAddedSuccessfully()
        {
            _waitActions.WaitForElementDisplayed(txtShoppingHeader);
        }

        public void RemoveProductFromCart()
        {
            _waitActions.WaitForElementClickable(btnRemoveCartDelete);
            _waitActions.ClickElement(btnRemoveCartDelete);
        }
        public void VerifyCardIsEmpty()
        {
            _waitActions.WaitForElementDisplayed(txtCartIsEmpty);
        }
    }
}