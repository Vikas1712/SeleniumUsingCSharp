using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class ShipppingPage
    {
        private IWebDriver _driver;
        private WaitActionPage _waitActions;

        public ShipppingPage(IWebDriver driver)
        {
            _driver = driver;
            _waitActions = new WaitActionPage(driver);
        }

        private readonly By checkBoxTermsAndConition = By.CssSelector("#cgv");
        private readonly By btnShippingProceedToCheckout = By.CssSelector("button[name = 'processCarrier'] span");
        
        public void AgreeTermsAndContions()
        {
            _driver.FindElement(checkBoxTermsAndConition).Click();
        }

        public void SelectProceedToCheckout()
        {
            _waitActions.WaitForElementClickable(btnShippingProceedToCheckout);
            _waitActions.ClickElement(btnShippingProceedToCheckout);
        }
    }
}
