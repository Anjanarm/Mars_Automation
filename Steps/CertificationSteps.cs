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
    public class CertificationSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly NavigationHelper _navigationHelper;
        private List<CertificationData> _certList;
        private List<CertificationEditData> _editCertList;
        private CertificationData _updateData;

        public CertificationSteps(LoginPage loginPage, HomePage homePage, NavigationHelper navigationHelper)
        {
            _loginPage = loginPage;
            _homePage = homePage;
            _navigationHelper = navigationHelper;
        }
        [Given("I load all certification details from {string} for {string}")]
        public void GivenILoadAllCertificationDetailsFromFor(string filename, string data)
        {
            //var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", fileName);
            //var jsonContent = File.ReadAllText(fullPath);

            //var allData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);
            string currentDir = Directory.GetCurrentDirectory();
            string certificationPath = Path.Combine(currentDir, "Tests", "CertificationTestData.json");
            //
            //
            //Console.WriteLine("Looking for: " + certificationPath);

            string json = File.ReadAllText(certificationPath);
            //_testdata = JsonSerializer.Deserialize<TestSettings>(json);
            var allData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (data == "EditData")
            {
                _editCertList = JsonConvert.DeserializeObject<List<CertificationEditData>>(allData[data].ToString());
            }
            else
            {
                _certList = JsonConvert.DeserializeObject<List<CertificationData>>(allData[data].ToString());
            }

        }
        [When("I add all certification entries")]
        public void WhenIAddAllCertificationEntries()
        {
            foreach(var cert in _certList)
            {
                _homePage.AddCertification(cert);
            }
        }
        [Then("I should see all the details")]
        public void ThenIShouldSeeAllTheDetails()
        {
            foreach (var cert in _certList)
            {
                bool certificateExists = _homePage.CertificateExists(cert);
                if(!certificateExists)
                    throw new Exception("cert.Certification not found");
            }
        }
        [Then("I should see error message")]
        public void ThenIShouldSeeErrorMessage()
        {
            string errorMessage = _homePage.CertificationDataIncomplete();
            Assert.That(errorMessage, Is.EqualTo("Please enter Certification Name, Certification From and Certification Year"));
        }

        [Then("I should see duplicate certification data message")]
        public void ThenIShouldSeeDuplicateCertificationDataMessage()
        {
            string duplicateMessage = _homePage.DuplicateDataMessage();
            Assert.That(duplicateMessage, Is.EqualTo("This information is already exist."));
        }
        [When("I add the original entry")]
        public void WhenIAddTheOriginalEntry()
        {
            foreach (var editCert in _editCertList)
            {
                _homePage.AddCertification(editCert.Original);
            }
        }
        [When("I edit with updated entry")]
        public void WhenIEditWithUpdatedEntry()
        {
            foreach (var editCert in _editCertList)
            {
                _homePage.EditCertification(editCert.Updated); 
                _updateData = editCert.Updated; 
            }
        }
        [Then("I should see the updated certification")]
        public void ThenIShouldSeeTheUpdatedCertification()
        {
            string updatedMessage =_homePage.UpdatedCertification();
            Assert.That(updatedMessage, Is.EqualTo(_updateData.Certification + " has been updated to your certification"));
        }
        [When("I delete added Certification")]
        public void WhenIDeleteAddedCertification()
        {
            _homePage.DeleteCertification(); 
        }
        [Then("I should see the certification field removed")]
        public void ThenIShouldSeeTheCertificationFieldRemoved()
        {
            string DeletedCertificationMessage = _homePage.DeleteCertificationMessage();
            Assert.That(DeletedCertificationMessage.ToLower(), Does.Contain("deleted"));
        }





    }
}
