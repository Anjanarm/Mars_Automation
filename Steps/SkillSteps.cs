using qa_dotnet_cucumber.Pages;
using RazorEngine;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class SkillSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly NavigationHelper _navigationHelper;
        //private readonly IWebDriver _driver;

        public SkillSteps(LoginPage loginPage, HomePage homePage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            _homePage = homePage;
            _navigationHelper = navigationHelper;
        }
        

        [When("I enter skill as {string} and level as {string}")]
        public void WhenIEnterSkillAsAndLevelAs(string skill, string level)
        {
            _homePage.AddSkill(skill, level);
        }
        
        [When("I enter new skill")]
        public void WhenIEnterNewSkill()
        {
            _homePage.EditSkill();
        }
       
        [Then("I should see the new skill added")]
        public void ThenIShouldSeeTheNewSkillAdded()
        {
            string newlyAddedSkill = _homePage.NewlyAddedSkill();
            Assert.That(newlyAddedSkill, Is.EqualTo("Coding"));
        }
        [Then("I should see enter skill details message")]
        public void ThenIShouldSeeEnterSkillDetailsMessage()
        {
            string detailsMessage = _homePage.SkillDataIncomplete();
            Assert.That(detailsMessage, Is.EqualTo("Please enter skill and experience level"));
        }
        
        [Then("I should see duplicate skill data message")]
        public void ThenIShouldSeeDuplicateSkillDataMessage()
        {
            string duplicateMessage = _homePage.DuplicateDataMessage();
            Assert.That(duplicateMessage, Is.EqualTo("This skill already exist in your skill list")); 
        }
        [Then("I should see the updated skill")]
        public void ThenIShouldSeeTheUpdatedSkill()
        {
            string newlyAddedSkill = _homePage.NewlyAddedSkill();
            Thread.Sleep(6000);
            //_driver.Navigate().Refresh();
            Assert.That(newlyAddedSkill, Is.EqualTo("Landscaping"));
        }
        [When("I delete added skill data")]
        public void WhenIDeleteAddedSkillData()
        {
            _homePage.DeleteSkill();
        }
        [Then("I should see the skill field removed")]
        public void ThenIShouldSeeTheSkillFieldRemoved()
        {
            string DeletedSkillMessage = _homePage.DeleteLanguageMessage();
            Assert.That(DeletedSkillMessage.ToLower(), Does.Contain("deleted"));
        }

    }
}
