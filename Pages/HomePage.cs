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
        private readonly By WelcomeMessage = By.XPath("//span[@class='item ui dropdown link active visible']");
        private readonly By AddNewField = By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']");
        private readonly By AddLanguageElement = By.XPath("//input[@placeholder='Add Language']");
        private readonly By ChooseLevel = By.XPath("//select[@name='level']");
        private readonly By AddOption = By.XPath("//input[@value='Add']");
        private readonly By FirstRow = By.XPath("(//tbody)[1]");
        private readonly By LanguagePopUp = By.XPath("//div[@class='ns-box-inner']");
        private readonly By DuplicateData = By.XPath("//div[@class='ns-box-inner'and text() = 'Duplicated Data']");
        private readonly By EditLanguageElement = By.XPath("(//tbody/tr[last()]/td[3]//i[contains(@class, 'write')])[last()]");
        private readonly By UpdateField = By.XPath("//input[@value='Update']");
        private readonly By UpdateData = By.XPath("//div[@class='ns-box-inner'and text() = 'germen has been updated to your languages']");
        private readonly By DeleteLanguageElement = By.XPath("(//tbody/tr[last()]/td[3]//i[contains(@class, 'remove')])[last()]");
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
        public bool IsAtHomePage()
        {
            var pageHeadingElement = _wait.Until(ExpectedConditions.ElementIsVisible(WelcomeMessage));
            return pageHeadingElement.Text.Equals("Hi", StringComparison.OrdinalIgnoreCase);
            // return _driver.Title.Contains("Trade your skills for a new skill?");
        }
        public void AddLanguage(string language, string level)
        {
            var addNewElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddNewField));
            addNewElement.Click();
            var addLanguageField = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageElement));
            addLanguageField.SendKeys(language);
            var languageLevel = _wait.Until(ExpectedConditions.ElementToBeClickable(ChooseLevel));
            languageLevel.Click();
            languageLevel.SendKeys(level);
            var addElement = _wait.Until(d => d.FindElement(AddOption));
            addElement.Click();
        }
        public string LanguageAdded()
        {
            var firstRowContent = _wait.Until(d => d.FindElement(FirstRow));
            return firstRowContent.Text;
        }
        public string LanguageDataIncomplete()
        {
            var languageFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(LanguagePopUp));
            return languageFlashMessage.Text;
        }
        public string DuplicateDataMessage()
        {
            var duplicateFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(DuplicateData));
            return duplicateFlashMessage.Text;
        }
        public void EditLanguage()
        {
            var editLanguageField = _wait.Until(ExpectedConditions.ElementToBeClickable(EditLanguageElement));
            editLanguageField.Click();
            var editLanguageData = _wait.Until(ExpectedConditions.ElementIsVisible(AddLanguageElement));
            editLanguageData.Clear();
            editLanguageData.SendKeys("Germen");
            var updateLanguageField = _wait.Until(ExpectedConditions.ElementIsVisible(UpdateField));
            updateLanguageField.Click();
        }
        public string EditLanguageMessage()
        {
            var updateFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(UpdateData));
            return updateFlashMessage.Text;
        }
        public void DeleteLanguage()
        { 
            var deleteLanguageField = _wait.Until(ExpectedConditions.ElementToBeClickable(DeleteLanguageElement));
            deleteLanguageField.Click();
        }
        public string DeleteLanguageMessage()
        {
            var deleteFlashMessage = _wait.Until(ExpectedConditions.ElementIsVisible(LanguagePopUp));
            return deleteFlashMessage.Text;
        }


    }
}
