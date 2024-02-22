using BookWormSpecFlow.Helper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class CategoriesPage
    {
        private const string TitleCssSelector = ".woocommerce-loop-product__title";

        public static IReadOnlyCollection<IWebElement> GetBookListItems(IWebDriver driver)
        {
            return driver.FindElements(By.CssSelector(".products li.product"));
        }

        public static void ClickOnBookByTitle(IWebDriver driver, string bookTitle)
        {
            IReadOnlyCollection<IWebElement> bookListItems = GetBookListItems(driver);
            IWebElement bookElement = bookListItems.FirstOrDefault(element => element.FindElement(By.CssSelector(TitleCssSelector)).Text.Contains(bookTitle));
            bookElement?.Click();
        }

        public static List<string> GetBookTitles(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> bookListItems = GetBookListItems(driver);
            return bookListItems
                .Select(element => element.FindElement(By.CssSelector(".woocommerce-loop-product__title")).Text)
                .ToList();
        }

        public static string GetRandomBookTitle(IWebDriver driver)
        {
            var titles = GetBookTitles(driver);
            if (titles?.Count > 0)
            {
                return titles[Helpers.GetRandomNumber(titles.Count)];
            }
            Console.WriteLine("No filtered book link texts found.");
            return "";
        }

    }
