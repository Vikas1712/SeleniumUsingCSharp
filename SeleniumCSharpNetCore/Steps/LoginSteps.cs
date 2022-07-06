namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;
        public LoginSteps()
        {
            homePage = new HomePage();
            loginPage = new LoginPage();
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication() => homePage.OpenAutomationPracticeSite();


        [Given(@"I click the SignIn link")]
        public void GivenIClickTheSignInLink() => homePage.ClickSignIn();

        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            //loginPage.EnterUserNameAndPassword(data.UserName,data.Password);
            loginPage.ClickSubmitLogin();
        }

        [Given(@"I click SignIn Button")]
        public void GivenIClickSignInButton() => loginPage.ClickSubmitLogin();

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication() => loginPage.ClickSubmitLogin();

        [Given(@"I am on automation practice site")]
        public void GivenIAmOnAutomationPracticeSite() => DriverContext.Driver.Navigate().GoToUrl("http://automationpractice.com");
    }
}
