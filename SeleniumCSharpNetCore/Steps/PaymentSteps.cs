namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public class PaymentSteps
    {
        private readonly HomePage homePage;
        private readonly ProductPage productPage;
        private readonly CartPage cartPage;
        private readonly LoginPage loginPage;
        private readonly ShipppingPage shipppingPage;
        private readonly PaymentPage paymentPage;
        public PaymentSteps()
        {
            homePage = new HomePage();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cartPage = new CartPage();
            shipppingPage = new ShipppingPage();
            paymentPage = new PaymentPage();
        }

        [Given(@"User have products added to the cart")]
        public void GivenUserHaveProductsAddedToTheCart()
        {
            homePage.OpenAutomationPracticeSite();
            homePage.ClickSignIn();
            loginPage.RegisterUserNameAndPassword();
            loginPage.ClickSubmitLogin();
            productPage.SelectProductCategory();
            productPage.SelectProduct();
            productPage.ClickAddToCart();
            cartPage.SelectProceedToCheckout();
            cartPage.SelectSummaryProceedToCheckout();
            cartPage.SelectAddressProceedToCheckout();
            shipppingPage.AgreeTermsAndContions();
            shipppingPage.SelectProceedToCheckout();
        }

        [When(@"User makes the payment after filling all details")]
        public void WhenUserMakesThePaymentAfterFillingAllDetails()
        {
            paymentPage.MakePaymentbyCheck();
            paymentPage.SelectIConfirmMyOrder();
        }

        [Then(@"Confirmation is displayed to the user")]
        public void ThenConfirmationIsDisplayedToTheUser() => paymentPage.VerifyOrderPlaceSuccessfully();
    }
}
