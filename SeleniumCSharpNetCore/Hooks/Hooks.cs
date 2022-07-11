using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumCSharpNetCore.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;
        private static ExtentTest _featureName;
        private static ExtentReports extent;

        private static readonly string reportPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var type = _scenarioContext.ScenarioExecutionStatus.ToString();
            if (type == "UndefinedStep")
            {
                _currentScenarioName.Skip(_scenarioContext.ScenarioExecutionStatus.ToString());
            }
            DriverContext.Driver.Quit();
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) => _featureName = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);

        [BeforeScenario]
        public void BeforeScenario()
        {
            ConfigReader.SetFrameworkSettings();
            OpenBrowser(Settings.BrowserType);
            _currentScenarioName = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void InsertReportingStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "When":
                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "Then":
                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;

                    case "And":
                        _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                }
            }
            else if (_scenarioContext.TestError != null)
            {
                var mediaEntity = DriverContext.CaptureScreenShot(_scenarioContext.ScenarioInfo.Title.Trim());
                switch (stepType)
                {
                    case "Given":
                        _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                        break;

                    case "When":
                        _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                        break;

                    case "Then":
                        _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                        break;
                }
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        public static void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Edge:
                    new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                    DriverContext.Driver = new EdgeDriver();
                    break;

                case BrowserType.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                    DriverContext.Driver = new FirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    ChromeOptions option = new();
                    option.AddArguments("start-maximized");
                    option.AddArguments("--disable-gpu");
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    Console.WriteLine("Setup");
                    DriverContext.Driver = new ChromeDriver(option);
                    break;

                case BrowserType.Opera:
                    new DriverManager().SetUpDriver(new OperaConfig());
                    break;
            }
        }
    }
}