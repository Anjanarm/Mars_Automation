using qa_dotnet_cucumber.Pages;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class LanguageSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly NavigationHelper _navigationHelper;

        public LanguageSteps(LoginPage loginPage, HomePage homePage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            _homePage = homePage;
            _navigationHelper = navigationHelper;
        }
        [Given("I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            _navigationHelper.NavigateTo("Account/Profile");
            Assert.That(_homePage.IsAtHomePage(), Is.True, "Should be on the home page");
        }
        [When("I enter language and language level")]
        public void WhenIEnterLanguageAndLanguageLevel()
        {
            _homePage.AddLanguage("English", "Fluent");
        }
        [When("I enter language level and leave language empty")]
        public void WhenIEnterLanguageLevelAndLeaveLanguageEmpty()
        {
            _homePage.AddLanguage("", "Fluent");
        }
        [When("I enter language and leave language level empty")]
        public void WhenIEnterLanguageAndLeaveLanguageLevelEmpty()
        {
            _homePage.AddLanguage("Germen", "");
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
        public void WhenIDeleteALanguageData()
        {
            _homePage.DeleteLanguage();
        }


        [Then("I should see the new language added")]
        public void ThenIShouldSeeTheNewLanguageAdded()
        {
            string newlyAddedLanguage = _homePage.LanguageAdded();
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
            Assert.That(duplicateMessage, Is.EqualTo("Duplicated Data"));

        }
        

        [Then("I should see the updated data")]
        public void ThenIShouldSeeTheUpdatedData()
        {
           string UpdatedLanguageMessage = _homePage.EditLanguageMessage();
            Assert.That(UpdatedLanguageMessage, Is.EqualTo("germen has been updated to your languages"));
        }
        [Then("I should see the language field removed")]
        public void ThenIShouldSeeTheLanguageFieldRemoved()
        {
            string DeletedLanguageMessage = _homePage.DeleteLanguageMessage();
            Assert.That(DeletedLanguageMessage.ToLower(), Does.Contain("deleted"));

        }
    }

}
