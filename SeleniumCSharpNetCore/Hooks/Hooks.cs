﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpNetCore.Pages;
using System;
using System.IO;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCSharpNetCore.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly DriverHelper _driverHelper;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;
        private static ExtentTest _featureName;
        private static AventStack.ExtentReports.ExtentReports extent;

        static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy HHmmss");

        public Hooks(DriverHelper driverHelper,FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var type = _scenarioContext.ScenarioExecutionStatus.ToString();
            if(type == "UndefinedStep")
            {
                _currentScenarioName.Skip(_scenarioContext.ScenarioExecutionStatus.ToString());
            }
            _driverHelper.Driver.Quit();
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
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName = extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-gpu");
            new DriverManager().SetUpDriver(new ChromeConfig());
            Console.WriteLine("Setup");
            _driverHelper.Driver = new ChromeDriver(option);

            _currentScenarioName = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

        }

        [AfterStep]
        public void InsertReportingStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                var mediaEntity = _driverHelper.CaptureScreenShot(_scenarioContext.ScenarioInfo.Title.Trim());
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }
    }
}