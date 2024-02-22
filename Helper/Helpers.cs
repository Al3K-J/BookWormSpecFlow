using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWormSpecFlow.Helper
{
    public static class Helpers
    {
        public static int GetRandomNumber(int maxNumber, int minNumber = 0)
        {
            var random = new Random();
            var randomIndex = random.Next(minNumber, maxNumber);
            return randomIndex - 1;
        }

        public static bool IsElementPresent(IWebDriver driver, By by, int waitSeconds = 5)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
