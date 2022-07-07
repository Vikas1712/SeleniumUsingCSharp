namespace SeleniumCSharpNetCore.Pages
{
    public class PaymentPage:BasePage
    {
        public WaitActionPage _waitActions = new WaitActionPage();
        private readonly By btnPayBycheck = By.CssSelector("a[title='Pay by check.']");
        private readonly By btnIConfirmMyOrder = By.CssSelector("button[class='button btn btn-default button-medium'] span");
        private readonly By alertOrderConfirmation = By.CssSelector(".alert.alert-success");
        public void MakePaymentbyCheck() => _waitActions.ClickElement(btnPayBycheck);
        public void SelectIConfirmMyOrder() => _waitActions.ClickElement(btnIConfirmMyOrder);
        public void VerifyOrderPlaceSuccessfully() => _waitActions.WaitForElementDisplayed(alertOrderConfirmation);
    }
}
