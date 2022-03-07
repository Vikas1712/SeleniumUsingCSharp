using SeleniumCSharpNetCore.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public sealed class LoginSteps : DriverHelper
    {
        HomePage homePage = new HomePage();
        LoginPage loginPage = new LoginPage();

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com");
            Driver.Manage().Window.Maximize();
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
