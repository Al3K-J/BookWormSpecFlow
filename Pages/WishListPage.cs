using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

public static class WishListPage
{
    public static By wishlistNameInputFieldLocator = By.Name("wishlist_name");
    public static By saveButtonWishlistTitleLocator = By.CssSelector(".save-title-form");
    public static By productNameLocator = By.XPath("//td[@class='product-name']/a");
    public static By wishListTitleLocator = By.CssSelector(".wishlist-title-with-form h2");


    public static void ValidateThatBookIsAddedToWIshList(IWebDriver driver)
    {

        IWebElement productNameElement = driver.FindElement(productNameLocator);
        string text = productNameElement.Text.Trim();
        Console.WriteLine($"Product Name Text: {text}");
        Assert.IsTrue(productNameElement.Displayed, "Product name element is not visible.");


    }

    public static void AddNewWishlistTitle(IWebDriver driver, string newBookTitle)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(wishlistNameInputFieldLocator));
        driver.FindElement(wishlistNameInputFieldLocator).Clear();

        driver.FindElement(wishlistNameInputFieldLocator).SendKeys(newBookTitle);

        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".blockUI.blockOverlay")));

        wait.Until(ExpectedConditions.ElementIsVisible(saveButtonWishlistTitleLocator));
        driver.FindElement(saveButtonWishlistTitleLocator).Click();

        wait.Until(driver => driver.FindElement(wishListTitleLocator).Text.Equals(newBookTitle));
    }

    public static void ValidateThatBookTitleIsEdited(IWebDriver driver, string newBookTitle)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        try
        {
            wait.Until(ExpectedConditions.ElementIsVisible(wishListTitleLocator));
            IWebElement title = driver.FindElement(wishListTitleLocator);
            Assert.AreEqual(newBookTitle, title.Text, "Title not updated!");
        }
        catch (WebDriverTimeoutException)
        {
            Assert.Fail("Timeout waiting for the wishlist title element to be visible.");
        }
    }

}
