using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    }
}
