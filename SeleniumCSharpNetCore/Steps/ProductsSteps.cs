using SeleniumCSharpNetCore.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public class ProductsSteps
    {
        private DriverHelper _driverHelper;
        LoginPage loginPage;
        ProductPage productPage;

        public ProductsSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            loginPage = new LoginPage(_driverHelper.Driver);
            productPage = new ProductPage(_driverHelper.Driver);
        }

        [Given(@"User is on automation practice site")]
        public void GivenUserIsOnAutomationPracticeSite()
        {
            loginPage.OpenAutomationPracticeSite();
        }
        
        [Given(@"User have selected a category on the website")]
        public void GivenUserHaveSelectedACategoryOnTheWebsite()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User selects a product from the list")]
        public void WhenUserSelectsAProductFromTheList()
        {
            productPage.SelectProductCategory();
        }
        
        [When(@"User applys filter to the products")]
        public void WhenUserApplysFilterToTheProducts()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"All the details related to products are visible")]
        public void ThenAllTheDetailsRelatedToProductsAreVisible()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The page is updated with correct products")]
        public void ThenThePageIsUpdatedWithCorrectProducts()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
