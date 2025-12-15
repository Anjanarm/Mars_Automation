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
using NUnit.Framework.Internal.Execution;
namespace qa_dotnet_cucumber.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
       
        private static TestSettings _settings;
        public static TestSettings Settings => _settings;
        private static readonly object _reportLock = new object();
        private static ExtentReports _extent;
        private static ExtentSparkReporter _htmlReporter;
        //private ExtentTest _test;
        public static ExtentTest _scenario;

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
            //string currentDir = Directory.GetCurrentDirectory();
            string projectRoot = Path.GetFullPath(Path.Combine(currentDir, "..", ".."));
            string reportFileName = _settings.Report.Path.TrimStart('/');
            string reportPath = Path.Combine(projectRoot, reportFileName);
            _htmlReporter = new ExtentSparkReporter(reportPath);
            _htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;
            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);
            _extent.AddSystemInfo("Environment", _settings.Environment.BaseUrl);
            _extent.AddSystemInfo("Browser", _settings.Browser.Type);


        }

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

        [AfterTestRun]

        public static void AfterTestRun()
        {
            _extent.Flush();
        }
        


        [BeforeScenario]
        
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            
            new DriverManager().SetUpDriver(new ChromeConfig());
            var chromeOptions = new ChromeOptions();
            
            var driver = new ChromeDriver(chromeOptions);
            
            driver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);

            _scenario = _extent.CreateTest(scenarioContext.ScenarioInfo.Title);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            var _homePage = new HomePage(driver);
            Thread.Sleep(2000);
            _homePage.DeleteGeneratedRows();
            driver.Quit();
            Console.WriteLine($"Finished scenario on Thread {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now}");
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepText = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                _scenario.Log(Status.Pass, $"{stepType}: {stepText}");
            }
            else
            {
                _scenario.Log(Status.Fail,
                    $"{stepType}: {stepText}<br>Error: {scenarioContext.TestError.Message}");
            }
        }


    }
}