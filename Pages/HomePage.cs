using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Log;
using OpenQA.Selenium.DevTools.V137.Network;
using OpenQA.Selenium.Support.UI;
using qa_dotnet_cucumber.Tests;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qa_dotnet_cucumber.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public IWebDriver Driver => _driver;

        private readonly By SignoutButton = By.XPath("//button[normalize-space()='Sign Out']");
        private readonly By WelcomeMessage = By.XPath("//span[contains(@class,'ui') and contains(@class,'dropdown')]");
        private readonly By AddNewLanguage = By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']");
        private readonly By AddLanguageElement = By.XPath("//input[@placeholder='Add Language']");
        private readonly By ChooseLevel = By.XPath("//select[@name='level']");
        private readonly By AddOption = By.XPath("//input[@value='Add']");
        private readonly By FirstRow = By.XPath("//table[@class='ui fixed table']//tbody/tr[1]/td[1]");
        private readonly By LanguagePopUp = By.XPath("//div[@class='ns-box-inner']");
        private readonly By EditLanguageElement = By.XPath("//td[@class='right aligned']//i[@class='outline write icon']");
        private readonly By UpdateField = By.XPath("//input[@value='Update']");
        private readonly By DeleteLanguageElement = By.XPath("//td[@class='right aligned']//i[@class='remove icon']");
        private readonly By SkillsTab = By.XPath("//a[normalize-space()='Skills']");
        private readonly By AddSkillElement = By.XPath("//input[@placeholder='Add Skill']");
        private readonly By AddNewSkill = By.XPath("//div[@data-tab='second']//div[contains(@class,'ui teal button')][normalize-space()='Add New']");
        private readonly By SkillPopUp = By.XPath("//div[@class='ns-box-inner']");
        private readonly By EditSkillElement = By.XPath("//div[@data-tab='second']//td[@class='right aligned']//i[@class='outline write icon']");
        private readonly By UpdateSkillField = By.XPath("//div[@data-tab='second']//input[@value='Update']");
        private readonly By DeleteSkillElement = By.XPath("//div[@data-tab='second']//td[@class='right aligned']//i[@class='remove icon']");
        private readonly By Rows = By.XPath("//tbody/tr");
        private readonly By EntireFirstRow = By.XPath("//table[@class='ui fixed table']//tbody/tr[1]");
        private readonly By DeleteRow = By.XPath("//td[@class='right aligned']//i[@class='remove icon']");
        private readonly By EducationTab = By.XPath("//a[normalize-space()='Education']");
        private readonly By AddNewEducation = By.XPath("//div[@data-tab='third']//div[contains(@class,'ui teal button')][normalize-space()='Add New']");
        private readonly By UniversityElement = By.XPath("//input[@placeholder='College/University Name']");
        private readonly By CountryElement = By.XPath("//select[@name='country']");
        private readonly By TitleElement = By.XPath("//select[@name='title']");
        private readonly By DegreeElement = By.XPath("//input[@placeholder='Degree']");
        private readonly By YearElement = By.XPath("//select[@name='yearOfGraduation']");
        private readonly By EducationRows = By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//table[@class='ui fixed table']//tr");
        private readonly By EditEducationElement = By.XPath("//div[@data-tab='third']//td[@class='right aligned']//i[@class='outline write icon']");
        private readonly By UpdateEducationElement = By.XPath("//div[@data-tab='third']//input[@value='Update']");
        private readonly By DeleteEducationElement = By.XPath("//div[@data-tab='third']//td[@class='right aligned']//i[@class='remove icon']");
        private readonly By EducationPopUp = By.XPath("//div[@class='ns-box-inner']");
        private readonly By CertificationTab = By.XPath("//a[normalize-space()='Certifications']");
        private readonly By AddNewCertification = By.XPath("//div[@data-tab='fourth']//div[contains(@class,'ui teal button')][normalize-space()='Add New']");
        private readonly By CertificationRows = By.XPath("//div[@class='ui bottom attached tab segment tooltip-target active']//table[@class='ui fixed table']//tr");
        private readonly By CertificationElement = By.XPath("//input[@placeholder='Certificate or Award']");
        private readonly By IssuedFrom = By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']");
        private readonly By IssueYear = By.XPath("//select[@name='certificationYear']");
        private readonly By CertificationPopUp = By.XPath("//div[@class='ns-box-inner']");
        private readonly By EditCertificationElement = By.XPath("//div[@data-tab='fourth']//td[@class='right aligned']//i[@class='outline write icon']");
        private readonly By UpdateCertificationElement = By.XPath("//div[@data-tab='fourth']//input[@value='Update']");
        private readonly By DeleteCertificationElement = By.XPath("//div[@data-tab='fourth']//td[@class='right aligned']//i[@class='remove icon']");
        public HomePage(IWebDriver driver) // Inject IWebDriver directly
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // 10-second timeout
        }
        public string GetSuccessMessage()
        {
            var signoutButton = _wait.Until(d => d.FindElement(SignoutButton));
            return signoutButton.Text;
        }
        public string IsAtHomePage()
        {
            var pageHeadingElement = _wait.Until(d => d.FindElement(WelcomeMessage));
            return pageHeadingElement.Text;
     
        }
        public void AddLanguage(string language, string level)
        {
            var addNewElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewLanguage));
            addNewElement.Click();
            var addLanguageField = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageElement));
            addLanguageField.SendKeys(language);
            var languageLevel = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseLevel));
            languageLevel.Click();
            languageLevel.SendKeys(level);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
            //_driver.Navigate().Refresh();
            Thread.Sleep(3000);
        }
        public string NewlyAdded()
        {
            _driver.Navigate().Refresh();
            var firstRowContent = _wait.Until(ExpectedConditions.ElementIsVisible(FirstRow));
            return firstRowContent.Text;
        }
        public string NewlyAddedSkill()
        {
            _driver.Navigate().Refresh();
            var skillSelect = _wait.Until(d => d.FindElement(SkillsTab));
            skillSelect.Click();
            var firstRowContent = _wait.Until(ExpectedConditions.ElementIsVisible(FirstRow));
            return firstRowContent.Text;
        }
        public string LanguageDataIncomplete()
        {
            var languageFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(LanguagePopUp));
            return languageFlashMessage.Text;
        }
        public string SkillDataIncomplete()
        {
            var skillFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(SkillPopUp));
            return skillFlashMessage.Text;
        }
        public string DuplicateDataMessage()
        {
            var duplicateFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(LanguagePopUp));
            return duplicateFlashMessage.Text;
        }
        public void EditLanguage()
        {
            var editLanguageField = _wait.Until(ExpectedConditions.ElementToBeClickable(EditLanguageElement));
            editLanguageField.Click();
            var editLanguageData = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageElement));
            editLanguageData.Clear();
            editLanguageData = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageElement));
            editLanguageData.SendKeys("Tamil");
            var updateLanguageField = _wait.Until(ExpectedConditions.ElementIsVisible(UpdateField));
            updateLanguageField.Click();
        }
        public string EditLanguageMessage()
        {
            var updateFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(LanguagePopUp));
            return updateFlashMessage.Text;
        }
        public void DeleteLanguage()
        { 
            var deleteLanguageField = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguageElement));
            deleteLanguageField.Click();
        }
        public string DeleteLanguageMessage()
        {
            Thread.Sleep(3000);
            var deleteFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(LanguagePopUp));
            return deleteFlashMessage.Text;

        }
        
        public void AddSkill(string skill, string level)
        {
            var skillSelect = _wait.Until(d => d.FindElement(SkillsTab));
            skillSelect.Click();
            var addNewElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewSkill));
            addNewElement.Click();
            var addSkillField = _wait.Until(ExpectedConditions.ElementIsVisible(AddSkillElement));
            addSkillField.SendKeys(skill);
            var skillLevel = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseLevel));
            skillLevel.Click();
            skillLevel.SendKeys(level);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
            //_driver.Navigate().Refresh();
            Thread.Sleep(3000);
        }
        
        public void EditSkill()
        {
            var editSkillField = _wait.Until(ExpectedConditions.ElementToBeClickable(EditSkillElement));
            editSkillField.Click();
            var editSkillData = _wait.Until(ExpectedConditions.ElementIsVisible(AddSkillElement));
            editSkillData.Clear();
            editSkillData = _wait.Until(ExpectedConditions.ElementIsVisible(AddSkillElement));
            editSkillData.SendKeys("Landscaping");
            var updateLanguageField = _wait.Until(ExpectedConditions.ElementIsVisible(UpdateSkillField));
            updateLanguageField.Click();
        }
        public void DeleteSkill()
        {
            var deleteSkillField = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteSkillElement));
            deleteSkillField.Click();
        }
        public string DeleteSkillMessage()
        {
            Thread.Sleep(3000);
            var deleteFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(SkillPopUp));
            return deleteFlashMessage.Text;

        }
        public void DeleteGeneratedRows()
        {
            try
            {
               
                var rows = _wait.Until(d => d.FindElements(Rows));

                while (rows.Count > 0)
                {
                    var firstRow = _wait.Until(ExpectedConditions.ElementIsVisible(EntireFirstRow));
                    var deleteIcon = firstRow.FindElement(DeleteRow);
                    deleteIcon.Click();

                    Thread.Sleep(1000);
                    rows = _wait.Until(d => d.FindElements(Rows));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Cleanup] Failed to delete rows: {ex.Message}");
            }
        }
        public void AddEducation(string university, string country, string title, string degree, string year)
        {
            var educationSelect = _wait.Until(d => d.FindElement(EducationTab));
            educationSelect.Click();
            var addNewElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewEducation));
            addNewElement.Click();
            var universityField = _wait.Until(ExpectedConditions.ElementIsVisible(UniversityElement));
            universityField.Clear();
            universityField.SendKeys(university);
            var countryField = _wait.Until(ExpectedConditions.ElementToBeClickable(CountryElement));
            countryField.Click();
            countryField.SendKeys(country);
            var titleField = _wait.Until(ExpectedConditions.ElementToBeClickable(TitleElement));
            titleField.Click();
            titleField.SendKeys(title);
            var degreeField = _wait.Until(ExpectedConditions.ElementIsVisible(DegreeElement));
            degreeField.Clear();
            degreeField.SendKeys(degree);
            var yearField = _wait.Until(ExpectedConditions.ElementToBeClickable(YearElement));
            yearField.Click();
            yearField.SendKeys(year);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
            //_driver.Navigate().Refresh();
            Thread.Sleep(3000);
        }
        public bool VerifyEducatucationDetails(string university, string country, string title, string degree, string year)
        {
            var rows = _wait.Until(d => d.FindElements(EducationRows)); 
            foreach (var row in rows)
            {
                if (row.Text.Contains(university) &&
                    row.Text.Contains(country) &&
                    row.Text.Contains(title) &&
                    row.Text.Contains(degree) &&
                    row.Text.Contains(year))
                {
                    return true;
                }
            }
            return false;
        }
        public void EditEducation(string university)
        {
            var editEducationField = _wait.Until(ExpectedConditions.ElementToBeClickable(EditEducationElement));
            editEducationField.Click();
            var universityField = _wait.Until(ExpectedConditions.ElementToBeClickable(UniversityElement));
            universityField.Clear();
            universityField.SendKeys(university);
            var updateEducationField = _wait.Until(ExpectedConditions.ElementIsVisible(UpdateEducationElement));
            updateEducationField.Click();
            Thread.Sleep(3000);
        }
        public string EducationDataIncomplete()
        {
            var educationFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(EducationPopUp));
            return educationFlashMessage.Text;
        }
        public string VerifyUpdatedEducation()
        {
            Thread.Sleep(3000);
            var university = _wait.Until(d => d.FindElement(UniversityElement));
            //SelectElement select = new SelectElement(title);
            Console.WriteLine(university);
            return university.Text;
        }
        public void DeleteEducation()
        {
            var deleteEducationField = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteEducationElement));
            deleteEducationField.Click();
        }
        public string DeleteEducationMessage()
        {
            Thread.Sleep(3000);
            var deleteFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(EducationPopUp));
            return deleteFlashMessage.Text;
        }
        public void AddCertification(CertificationData cert)
        {
            var certificationSelect = _wait.Until(d => d.FindElement(CertificationTab));
            certificationSelect.Click();
            var addNewElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewCertification));
            addNewElement.Click();
            var CertificationField = _wait.Until(ExpectedConditions.ElementIsVisible(CertificationElement));
            CertificationField.SendKeys(cert.Certification);
            var certificationFrom = _wait.Until(ExpectedConditions.ElementToBeClickable(IssuedFrom));
            certificationFrom.SendKeys(cert.From);
            var certificationYear = _wait.Until(ExpectedConditions.ElementToBeClickable(IssueYear));
            certificationYear.Click();
            certificationYear.SendKeys(cert.Year);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
            //_driver.Navigate().Refresh();
            Thread.Sleep(3000);

        }
        public void EditCertification(CertificationData cert)
        {
            var editCertificationField = _wait.Until(ExpectedConditions.ElementToBeClickable(EditCertificationElement));
            editCertificationField.Click();
            var CertificationField = _wait.Until(ExpectedConditions.ElementIsVisible(CertificationElement));
            CertificationField.Clear();
            CertificationField.SendKeys(cert.Certification);
            var certificationFrom = _wait.Until(ExpectedConditions.ElementToBeClickable(IssuedFrom));
            certificationFrom.Clear();
            certificationFrom.SendKeys(cert.From);
            var certificationYear = _wait.Until(ExpectedConditions.ElementToBeClickable(IssueYear));
            certificationYear.Click();
            certificationYear.SendKeys(cert.Year);
            var updateCertificationField = _wait.Until(ExpectedConditions.ElementIsVisible(UpdateCertificationElement));
            updateCertificationField.Click();
            //_driver.Navigate().Refresh();
            Thread.Sleep(3000);

        }
        public bool CertificateExists(CertificationData cert)
        {
            var rows = _wait.Until(d => d.FindElements(CertificationRows));
            foreach (var row in rows)
            {
                if (row.Text.Contains(cert.Certification) &&
                    row.Text.Contains(cert.From) &&
                    row.Text.Contains(cert.Year))
                {
                    return true;
                }
            }
            return false;
        }
        public string CertificationDataIncomplete()
        {
            var certificationFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(CertificationPopUp));
            return certificationFlashMessage.Text;
        }

        public string UpdatedCertification()
        {
            var certificationFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(CertificationPopUp));
            return certificationFlashMessage.Text;
        }
        public void DeleteCertification()
        {
            var deleteCertificationField = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteCertificationElement));
            deleteCertificationField.Click();
        }
        public string DeleteCertificationMessage()
        {
            Thread.Sleep(3000);
            var deleteFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(CertificationPopUp));
            return deleteFlashMessage.Text;
        }
        public void AddEducation(EducationData edu)
        {
            var educationSelect = _wait.Until(d => d.FindElement(EducationTab));
            educationSelect.Click();
            var addNewElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewEducation));
            addNewElement.Click();
            var universityField = _wait.Until(ExpectedConditions.ElementIsVisible(UniversityElement));
            universityField.Clear();
            universityField.SendKeys(edu.University);
            var countryField = _wait.Until(ExpectedConditions.ElementToBeClickable(CountryElement));
            countryField.Click();
            countryField.SendKeys(edu.Country);
            var titleField = _wait.Until(ExpectedConditions.ElementToBeClickable(TitleElement));
            titleField.Click();
            titleField.SendKeys(edu.Title);
            var degreeField = _wait.Until(ExpectedConditions.ElementIsVisible(DegreeElement));
            degreeField.Clear();
            degreeField.SendKeys(edu.Degree);
            var yearField = _wait.Until(ExpectedConditions.ElementToBeClickable(YearElement));
            yearField.Click();
            yearField.SendKeys(edu.Year);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
            //_driver.Navigate().Refresh();
            Thread.Sleep(3000);
        }
        public bool EducationExists(EducationData edu)
        {
            var rows = _wait.Until(d => d.FindElements(EducationRows));
            foreach (var row in rows)
            {
                if (row.Text.Contains(edu.University) &&
                    row.Text.Contains(edu.Country) &&
                    row.Text.Contains(edu.Title) &&
                    row.Text.Contains(edu.Degree) &&
                    row.Text.Contains(edu.Year))
                {
                    return true;
                }
            }
            return false;
        }
        public void EditEducation(EducationData edu)
        {
            var editEducationField = _wait.Until(ExpectedConditions.ElementToBeClickable(EditEducationElement));
            editEducationField.Click();
            var universityField = _wait.Until(ExpectedConditions.ElementIsVisible(UniversityElement));
            universityField.Clear();
            universityField.SendKeys(edu.University);
            var countryField = _wait.Until(ExpectedConditions.ElementToBeClickable(CountryElement));
            countryField.Click();
            countryField.SendKeys(edu.Country);
            var titleField = _wait.Until(ExpectedConditions.ElementToBeClickable(TitleElement));
            titleField.Click();
            titleField.SendKeys(edu.Title);
            var degreeField = _wait.Until(ExpectedConditions.ElementIsVisible(DegreeElement));
            degreeField.Clear();
            degreeField.SendKeys(edu.Degree);
            var yearField = _wait.Until(ExpectedConditions.ElementToBeClickable(YearElement));
            yearField.Click();
            yearField.SendKeys(edu.Year);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
            //_driver.Navigate().Refresh();
            Thread.Sleep(3000);

        }
        public string UpdatedEducation()
        {
            var educationFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(EducationPopUp));
            return educationFlashMessage.Text;
        }

    }
}
