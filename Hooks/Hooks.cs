using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Gherkin.Ast;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BookWormSpecFlow.Hooks
{
    [Binding]
    public sealed class Hooks 
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
           
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {


        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
           
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            

           
        }
    }
}