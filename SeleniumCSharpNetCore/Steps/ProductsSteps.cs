using NUnit.Framework;
using SeleniumCSharpNetCore.Pages;
using TechTalk.SpecFlow;

namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public class ProductsSteps
    {
        private DriverHelper _driverHelper;
        HomePage homePage;
        LoginPage loginPage;
        ProductPage productPage;
        private int beforeCount;
        private int afterCount;

        public ProductsSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new LoginPage(_driverHelper.Driver);
            homePage = new HomePage(_driverHelper.Driver); 
            productPage = new ProductPage(_driverHelper.Driver);
        }

        [Given(@"User is on automation practice site")]
        public void GivenUserIsOnAutomationPracticeSite() => homePage.OpenAutomationPracticeSite();

        [Given(@"User have selected a category on the website")]
        public void GivenUserHaveSelectedACategoryOnTheWebsite()
        {
            homePage.OpenAutomationPracticeSite();
            productPage.SelectProductCategory();
        }
        
        [When(@"User selects a product from the list")]
        public void WhenUserSelectsAProductFromTheList()
        {
            productPage.SelectProductCategory();
            productPage.SelectProduct();
        }
        
        [When(@"User applys filter to the products")]
        public void WhenUserApplysFilterToTheProducts()
        {
            beforeCount= productPage.CountNumberOfProducts();
            productPage.SetFilterBasedOnCategory();
            afterCount = productPage.CountNumberOfProducts();
        }

        [Then(@"All the details related to products are visible")]
        public void ThenAllTheDetailsRelatedToProductsAreVisible() => productPage.ViewProductDetail();

        [Then(@"The page is updated with correct products")]
        public void ThenThePageIsUpdatedWithCorrectProducts() => Assert.AreEqual(beforeCount, afterCount);
    }
}
