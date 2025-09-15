using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using qa_dotnet_cucumber.Pages;
using Reqnroll;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.ClipRectangle;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly NavigationHelper _navigationHelper;

        public LoginSteps(LoginPage loginPage, HomePage homePage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            _homePage = homePage;
            _navigationHelper =  navigationHelper;
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _navigationHelper.NavigateTo("");
            Assert.That(_loginPage.IsAtLoginPage(), Is.True, "Should be on the login page"); 
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            _loginPage.Login("anjanarmaus@outlook.com", "123123");
        }

        [When("I enter an invalid username and valid password")]
        public void WhenIEnterAnInvalidUsernameAndValidPassword()
        {
            _loginPage.Login("invaliduser", "123123");
        }

        [When("I enter a valid username and invalid password")]
        public void WhenIEnterAValidUsernameAndInvalidPassword()
        {
            _loginPage.Login("anjanarmaus@outlook.com", "wrongpassword");
        }

        [When("I enter empty credentials")]
        public void WhenIEnterEmptyCredentials()
        {
            _loginPage.Login("","");
        }

        [Then("I should see the secure area")]
        public void ThenIShouldSeeTheSecureArea()
        {
            string successMessage = _homePage.GetSuccessMessage();
            Assert.That(successMessage, Is.EqualTo("Sign Out"));
        }

        [Then("I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            // Use LoginPage's driver to wait for and verify the error message
            //var wait = new WebDriverWait(_loginPage.Driver, TimeSpan.FromSeconds(20));

            //Assert.That(_loginPage.ErrorMessage(), Is.True, "Email confirmation displayed");
            var error = _loginPage.ErrorMessage();
            Assert.That(error, Is.EqualTo("Confirm your email"));
            //var errorMessageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(".flash.error")));
            // var errorMessage = errorMessageElement.Text;
            // Assert.That(errorMessage, Does.Match("Confirm your email"),
            //     "Should see an appropriate error message");
        }
    }
}