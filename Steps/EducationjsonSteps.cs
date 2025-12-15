using Newtonsoft.Json;
using qa_dotnet_cucumber.Config;
using qa_dotnet_cucumber.Pages;
using qa_dotnet_cucumber.Tests;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace qa_dotnet_cucumber.Steps
{
    [Binding]
    public class EducationjsonSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly NavigationHelper _navigationHelper;
        private List<EducationData> _eduList;
        private List<EducationEditData> _editEduList;
        private EducationData _updateData;

        public EducationjsonSteps(LoginPage loginPage, HomePage homePage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            _homePage = homePage;
            _navigationHelper = navigationHelper;
        }
        [Given("I load all Education details from {string} for {string}")]
        public void GivenILoadAllEducationDetailsFromFor(string filename, string data)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string certificationPath = Path.Combine(currentDir, "Tests", "EducationTestData.json");
            string json = File.ReadAllText(certificationPath);
            var allData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (data == "EditData")
            {
                _editEduList = JsonConvert.DeserializeObject<List<EducationEditData>>(allData[data].ToString());
            }
            else
            {
                _eduList = JsonConvert.DeserializeObject<List<EducationData>>(allData[data].ToString());
            }
        }
        [When("I add all Education entries")]
        public void WhenIAddAllEducationEntries()
        {
            foreach (var edu in _eduList)
            {
                _homePage.AddEducation(edu);
            }
        }
        [Then("I should see all the Education details")]
        public void ThenIShouldSeeAllTheEducationDetails()
        {
            foreach (var edu in _eduList)
            {
                bool educationExists = _homePage.EducationExists(edu);
                if (!educationExists)
                    throw new Exception("cert.Certification not found");
            }
        }
        [Then("I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            string errorMessage = _homePage.EducationDataIncomplete();
            Assert.That(errorMessage, Is.EqualTo("Please enter all the fields"));
            
        }
        [When("I add the original education entry")]
        public void WhenIAddTheOriginalEducationEntry()
        {
            foreach (var editEdu in _editEduList)
                {
                    _homePage.AddEducation(editEdu.Original);
                }
        }
        [When("I edit with updated education entry")]
        public void WhenIEditWithUpdatedEducationEntry()
        {
            foreach (var editEdu in _editEduList)
            {
                _homePage.EditEducation(editEdu.Updated);
                _updateData = editEdu.Updated;
            }
        }
        [Then("I should see the updated education")]
        public void ThenIShouldSeeTheUpdatedEducation()
        {
            string updatedMessage = _homePage.UpdatedEducation();
            Assert.That(updatedMessage, Is.EqualTo(_updateData.University + " has been updated to your education"));
        }
        [Then("I should see the education field removed")]
        public void ThenIShouldSeeTheEducationFieldRemoved()
        {
            string DeletedCertificationMessage = _homePage.DeleteEducationMessage();
            Assert.That(DeletedCertificationMessage.ToLower(), Does.Contain("deleted"));
        }



    }


}

