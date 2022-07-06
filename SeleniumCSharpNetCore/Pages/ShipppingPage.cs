namespace SeleniumCSharpNetCore.Pages
{
    public class ShipppingPage:BasePage
    {
        public WaitActionPage _waitActions = new WaitActionPage();
        private readonly By checkBoxTermsAndConition = By.CssSelector("#cgv");
        private readonly By btnShippingProceedToCheckout = By.CssSelector("button[name = 'processCarrier'] span");
        public void AgreeTermsAndContions() => DriverContext.Driver.FindElement(checkBoxTermsAndConition).Click();
        public void SelectProceedToCheckout() => _waitActions.ClickElement(btnShippingProceedToCheckout);
    }
}
