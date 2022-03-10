using SeleniumCSharpNetCore.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private DriverHelper _driverHelper;
        HomePage homePage;
        LoginPage loginPage;

        public LoginSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _driverHelper.Driver.Navigate().GoToUrl("http://automationpractice.com");
        }
        
        [Given(@"I click the SignIn link")]
        public void GivenIClickTheSignInLink()
        {
            homePage.ClickSignIn();
        }
        
        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.EnterUserNameAndPassword(data.UserName,data.Password);
        }
        
        [Given(@"I click SignIn Button")]
        public void GivenIClickSignInButton()
        {
            loginPage.ClickSignIn();
        }
        
        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            loginPage.ClickSignIn();
        }
    }
}
