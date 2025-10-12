using qa_dotnet_cucumber.Pages;
using Reqnroll;
using qa_dotnet_cucumber.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class LanguageSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly NavigationHelper _navigationHelper;
        //private readonly IWebDriver _driver;

        public LanguageSteps(LoginPage loginPage, HomePage homePage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            _homePage = homePage;
            _navigationHelper = navigationHelper;
        }
        [Given("I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            string user = _homePage.IsAtHomePage();
            Assert.That(user, Does.Contain("Hi"), "Should be on the home page");
        }
      

        [When("I enter {string} and {string}")]
        public void WhenIEnterAnd(string language, string level)
        {
            _homePage.AddLanguage(language, level);
        }

        [When("I enter existing language")]
        public void WhenIEnterExistingLanguage()
        {
            _homePage.AddLanguage("English", "Native");
        }
        [When("I enter new details")]
        public void WhenIEnterNewDetails()
        {
            _homePage.EditLanguage();
        }
        [When("I delete a language data")]
        
        [When("I delete added language data")]
        public void WhenIDeleteAddedLanguageData()
        {
            _homePage.DeleteLanguage();
        }
        [Then("I should see the new language added")]
        public void ThenIShouldSeeTheNewLanguageAdded()
        {
            string newlyAddedLanguage = _homePage.NewlyAdded();
            Assert.That(newlyAddedLanguage, Is.EqualTo("English"));
        }
        [Then("I should see enter details message")]
        public void ThenIShouldSeeEnterDetailsMessage()
        {
            string detailsMessage = _homePage.LanguageDataIncomplete();
            Assert.That(detailsMessage, Is.EqualTo("Please enter language and level"));
        }
        [Then("I should see duplicate data message")]
        public void ThenIShouldSeeDuplicateDataMessage()
        {
            string duplicateMessage = _homePage.DuplicateDataMessage();
            Assert.That(duplicateMessage, Is.EqualTo("Duplicated data"));

        }
        [Then("I should see the updated data")]
        public void ThenIShouldSeeTheUpdatedData()
        {
            string newlyAddedLanguage = _homePage.NewlyAdded();
            Thread.Sleep(6000);
            //_driver.Navigate().Refresh();
            Assert.That(newlyAddedLanguage, Is.EqualTo("Tamil"));
        }
        [Then("I should see the language field removed")]
        public void ThenIShouldSeeTheLanguageFieldRemoved()
        {
            string DeletedLanguageMessage = _homePage.DeleteLanguageMessage();
            Assert.That(DeletedLanguageMessage.ToLower(), Does.Contain("deleted"));

        }
    }

}
