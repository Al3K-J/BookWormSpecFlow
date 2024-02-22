using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class HomePage
{
    public static By CategoriesLink => By.LinkText("Categories");

    public static void GoToCategories(IWebDriver driver)
    {
        driver.FindElement(CategoriesLink).Click();
    }
}
