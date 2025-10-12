using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Text.Json;
using qa_dotnet_cucumber.Config;
using qa_dotnet_cucumber.Pages;
namespace qa_dotnet_cucumber.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
       
        private static TestSettings _settings;
        
        

        public static TestSettings Settings => _settings;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            
        }
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string settingsPath = Path.Combine(currentDir, "settings.json");
            string json = File.ReadAllText(settingsPath);
            _settings = JsonSerializer.Deserialize<TestSettings>(json);

            // Get project root by navigating up from bin/Debug/net8.0
            string projectRoot = Path.GetFullPath(Path.Combine(currentDir, "..", ".."));
            string reportFileName = _settings.Report.Path.TrimStart('/'); // e.g., "TestReport.html"
            string reportPath = Path.Combine(projectRoot, reportFileName);

            
            Console.WriteLine($"BeforeTestRun started at {DateTime.Now}, Report Path: {reportPath}");

        }
        
        [BeforeTestRun]
        public static void GlobalCleanup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var chromeOptions = new ChromeOptions();
            var driver = new ChromeDriver(chromeOptions);   
            driver.Manage().Window.Maximize();
            var username = _settings.Environment.username;
            var password = _settings.Environment.password;
            var loginPage = new LoginPage(driver);
            var navigationHelper = new NavigationHelper(driver);
            navigationHelper.NavigateTo("");
            loginPage.Login(username, password);

            var homePage = new HomePage(driver);
            homePage.DeleteGeneratedRows();  
            
            driver.Quit();  
        }
        


        [BeforeScenario]
        
        public void BeforeScenario()
        {
            
            new DriverManager().SetUpDriver(new ChromeConfig());
            var chromeOptions = new ChromeOptions();
            
            var driver = new ChromeDriver(chromeOptions);
            
            driver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            
            
           
        }
       
       
        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            var _homePage = new HomePage(driver);   
            _homePage.DeleteGeneratedRows();
            driver.Quit();
            Console.WriteLine($"Finished scenario on Thread {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now}");
        }
        
    }
}