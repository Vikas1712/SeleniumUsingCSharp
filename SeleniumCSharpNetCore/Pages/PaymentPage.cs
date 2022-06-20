using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class PaymentPage
    {
        private IWebDriver _driver;
        private WaitActionPage _waitActions;

        public PaymentPage(IWebDriver driver)
        {
            _driver = driver;
            _waitActions = new WaitActionPage(driver);
        }

        private readonly By btnPayBycheck = By.CssSelector("a[title='Pay by check.']");
        private readonly By btnIConfirmMyOrder = By.CssSelector("button[class='button btn btn-default button-medium'] span");
        private readonly By txtOrderConfirmation = By.CssSelector(".page-heading");
        private readonly By alertOrderConfirmation = By.CssSelector(".alert.alert-success");

        public void MakePaymentbyCheck()
        {
            _waitActions.WaitForElementClickable(btnPayBycheck);
            _waitActions.ClickElement(btnPayBycheck);
        }
        public void SelectIConfirmMyOrder()
        {
            _waitActions.WaitForElementClickable(btnIConfirmMyOrder);
            _waitActions.ClickElement(btnIConfirmMyOrder);
        }
        public void VerifyOrderPlaceSuccessfully()
        {
            _waitActions.WaitForElementDisplayed(txtOrderConfirmation);
            _waitActions.WaitForElementDisplayed(alertOrderConfirmation);
        }
    }
}
