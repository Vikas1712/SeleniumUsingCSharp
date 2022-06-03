using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using SeleniumCSharpNetCore.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly DriverHelper _driverHelper;
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;
        public LoginSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            loginPage.OpenAutomationPracticeSite();
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
            //loginPage.EnterUserNameAndPassword(data.UserName,data.Password);
            loginPage.ClickSignIn();
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

        [Given(@"I am on automation practice site")]
        public void GivenIAmOnAutomationPracticeSite()
        {
            _driverHelper.Driver.Navigate().GoToUrl("http://automationpractice.com");
        }
    }
}
