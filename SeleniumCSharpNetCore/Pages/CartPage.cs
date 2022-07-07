namespace SeleniumCSharpNetCore.Pages
{
    public class CartPage: BasePage
    {
        public WaitActionPage _waitActions = new WaitActionPage();
        private readonly By txtProductAddedSuccessfully = By.CssSelector("div[class='layer_cart_product col-xs-12 col-md-6'] h2");
        private readonly By btnProceedToCheckout = By.CssSelector("a[title='Proceed to checkout'] span");
        private readonly By btnContinueShopping = By.CssSelector("span[title='Continue shopping'] span:nth-child(1)");
        private readonly By txtShoppingHeader = By.CssSelector("#summary_products_quantity");
        private readonly By btnRemoveCartDelete = By.CssSelector("td[class='cart_delete text-center'] div");
        private readonly By txtCartIsEmpty = By.CssSelector(".alert.alert-warning");
        private readonly By btnSummaryProceedToCheckout = By.CssSelector("a[class='button btn btn-default standard-checkout button-medium'] span");
        private readonly By btnAddressProceedToCheckout = By.CssSelector("button[name = 'processAddress'] span");
        
        public void SelectProceedToCheckout()=> _waitActions.ClickElement(btnProceedToCheckout);
        public void SelectSummaryProceedToCheckout() => _waitActions.ClickElement(btnSummaryProceedToCheckout);
        public ShipppingPage SelectAddressProceedToCheckout()
        {
            _waitActions.ClickElement(btnAddressProceedToCheckout);
            return GetInstance<ShipppingPage>();
        }
        public void SelectContinueToShopping() => _waitActions.ClickElement(btnContinueShopping);
        public void ViewCartDetail() => _waitActions.WaitForElementDisplayed(txtProductAddedSuccessfully);
        public void VerifyCardAddedSuccessfully() => _waitActions.WaitForElementDisplayed(txtShoppingHeader);
        public void RemoveProductFromCart() => _waitActions.ClickElement(btnRemoveCartDelete);
        public void VerifyCardIsEmpty() => _waitActions.WaitForElementDisplayed(txtCartIsEmpty);
    }
}
