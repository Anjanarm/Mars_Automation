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
        [Given("I enter {string} and {string}")]
        public void GivenIEnterAnd(string email, string password)
        {
            _loginPage.Login(email, password);
        }




        [Then("I should see an {string}")]
        public void ThenIShouldSeeAn(string outcome)
        {
            if (outcome == "secure area")
            {
                string successMessage = _homePage.GetSuccessMessage();
                Assert.That(successMessage, Is.EqualTo("Sign Out"));
            }
            else if (outcome == "error message")
            {
                var error = _loginPage.ErrorMessage();
                Assert.That(error, Is.EqualTo("Confirm your email"));
            }
        }
        

    }
}