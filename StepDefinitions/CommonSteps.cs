using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BookWormSpecFlow.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private IWebDriver driver;
        public string pageUrl = "https://bookworm.madrasthemes.com/";

        public CommonSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am on the Bookworm website")]
        public void GivenIAmOnTheBookwormWebsite()
        {
            driver.Navigate().GoToUrl(pageUrl);

        }

        [When(@"I navigate to the Categories Page")]
        public void WhenINavigateToTheCategoriesPage()
        {
            HomePage.GoToCategories(driver);

        }



    }
}
