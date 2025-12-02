using NUnit.Framework;
using qa_dotnet_cucumber.Pages;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class EducationSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly NavigationHelper _navigationHelper;

        public EducationSteps(LoginPage loginPage, HomePage homePage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            _homePage = homePage;
            _navigationHelper = navigationHelper;
        }
        [When("I enter Education details as {string}, {string}, {string}, {string}, {string}")]
        public void WhenIEnterEducationDetailsAs(string university, string country, string title, string degree, string year)
        {
            _homePage.AddEducation(university, country, title, degree, year);   
        }
        [Then("I should see the details including {string}, {string}, {string}, {string}, {string}")]
        public void ThenIShouldSeeTheDetailsIncluding(string university, string country, string title, string degree, string year)
        {
            bool result =_homePage.VerifyEducatucationDetails(university, country, title, degree, year);
            if (!result)
                throw new Exception("Not all expected education entries were found in the table.");
        }
        [Then("I should see enter education details message")]
        public void ThenIShouldSeeEnterEducationDetailsMessage()
        {
            string incompleteMessage = _homePage.EducationDataIncomplete();
            Assert.That(incompleteMessage, Is.EqualTo("Please enter all the fields"));
        }
        [Then("I should not see data added with {string}, {string}, {string}, {string}, {string}")]
        public void ThenIShouldNotSeeDataAddedWith(string university, string country, string title, string degree, string year)
        {
            bool result = _homePage.VerifyEducatucationDetails(university, country, title, degree, year);
            Assert.That(result, Is.False);                       
        }
        [Then("I should see duplicate Education data message")]
        public void ThenIShouldSeeDuplicateEducationDataMessage()
        {
            string duplicateMessage = _homePage.DuplicateDataMessage();
            Assert.That(duplicateMessage, Is.EqualTo("This information is already exist."));
        }
       
        [When("I edit Education details as")]
        public void WhenIEditEducationDetailsAs(DataTable dataTable)
        {
            var row = dataTable.Rows[0];
            string university = row["University"];
            _homePage.EditEducation(university);
        }
       
        [When("I delete added Education")]
        public void WhenIDeleteAddedEducation()
        {
            _homePage.DeleteEducation();
        }
        [Then("I should see the Education field removed")]
        public void ThenIShouldSeeTheEducationFieldRemoved()
        {
            string DeletedEducationMessage = _homePage.DeleteEducationMessage();
            Assert.That(DeletedEducationMessage.ToLower(), Does.Contain("removed"));
        }
        [Then("I should see the updated education with university as")]
        public void ThenIShouldSeeTheUpdatedEducationWithUniversityAs(DataTable dataTable)
        {
            var row = dataTable.Rows[0];
            string expectedUniversity = row["University"];
            string actualUniversity = _homePage.VerifyUpdatedEducation();
            Assert.That(actualUniversity, Is.EqualTo(expectedUniversity));
        }



    }
}
