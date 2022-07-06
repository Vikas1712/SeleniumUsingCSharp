namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public class CartSteps
    {
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;
        private readonly ProductPage productPage;
        private readonly CartPage cartPage;

        public CartSteps()
        {
            homePage = new HomePage();
            loginPage = new LoginPage();
            productPage = new ProductPage();
            cartPage = new CartPage(); 
        }

        [Given(@"Register User is on the product page")]
        public void GivenRegisterUserIsOnTheProductPage()
        {
            homePage.OpenAutomationPracticeSite();
            homePage.ClickSignIn();
            loginPage.RegisterUserNameAndPassword();
            loginPage.ClickSubmitLogin();
        }

        [When(@"User adds a product to the cart")]
        public void WhenUserAddsAProductToTheCart()
        {
            productPage.SelectProductCategory();
            productPage.SelectProduct();
            productPage.ViewProductDetail();
            productPage.ClickAddToCart();
        }

        [Then(@"The cart should be updated")]
        public void ThenTheCartShouldBeUpdated()
        {
            cartPage.ViewCartDetail();
            cartPage.SelectProceedToCheckout();
            cartPage.VerifyCardAddedSuccessfully();
        }

        [Given(@"User have added few products in the cart")]
        public void GivenUserHaveAddedFewProductsInTheCart()
        {
            homePage.OpenAutomationPracticeSite();
            productPage.SelectProductCategory();
            productPage.SelectProduct();
            productPage.ClickAddToCart();
            cartPage.SelectProceedToCheckout();
        }

        [When(@"User removes a product from the cart")]
        public void WhenUserRemovesAProductFromTheCart() => cartPage.RemoveProductFromCart();

        [Then(@"The cart should be empty")]
        public void ThenTheCartShouldBeEmpty() => cartPage.VerifyCardIsEmpty();

    }
}
