using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWormSpecFlow.Helper;

public static class BookDetailsPage
{
    private const string AddToCartCssSelector = "button.single_add_to_cart_button";
    private static readonly By AddToWishListLinkTextSelector = By.LinkText("Add to wishlist");
    private static readonly By AddToWishListButtonSelector = By.CssSelector(".add_to_wishlist");
    private static readonly By navigateToWishListLink = By.CssSelector("i.flaticon-heart.font-size-3");
    public const string SuccessMessageCssSelector = ".woocommerce-notices-wrapper .woocommerce-message";
    public static readonly By FormatDropdownSelector = By.Id("pa_format");

    public static void SelectRandomBookOptions(IWebDriver driver)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        try
        {
            if (Helpers.IsElementPresent(driver, FormatDropdownSelector))
            {
                var formatDropdown = new SelectElement(driver.FindElement(FormatDropdownSelector));
                var options = formatDropdown.Options.Skip(1).ToList();

                if (options.Count > 0)
                {
                    
                    wait.Until(ExpectedConditions.ElementToBeClickable(options[0]));

                    formatDropdown.SelectByIndex(Helpers.GetRandomNumber(options.Count, 1));
                }
                else
                {
                    Console.WriteLine("No valid options found in the dropdown.");
                }
            }
            else
            {
                Console.WriteLine("Dropdown element with id 'pa_format' not found.");
            }
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Timeout waiting for the dropdown element to be visible.");
        }
    }

    public static void ClickAddToCart(IWebDriver driver)
    {
        IWebElement addToCartButton = driver.FindElement(By.CssSelector(AddToCartCssSelector));
        addToCartButton?.Click();
    }


    public static bool IsSuccessMessageDisplayed(IWebDriver driver, string bookTitle)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement successMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(SuccessMessageCssSelector)));
            return successMessage.Text.Contains(bookTitle);
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public static void GoToCart(IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement successMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(SuccessMessageCssSelector)));

        string viewCartLink = successMessage.FindElement(By.CssSelector("a.button.wc-forward")).GetAttribute("href");
        driver.Navigate().GoToUrl(viewCartLink);
    }
    public static void ClickAddToWishlist(IWebDriver driver)
    {
        IWebElement addToWishListButton = driver.FindElement(AddToWishListButtonSelector);
        addToWishListButton?.Click();

    }
    public static void ProceedToWishlist(IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement waitForElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-title='Browse wishlist'] span.text")));

        int maxAttempts = 3;
        int attempt = 0;

        while (attempt < maxAttempts)
        {
            try
            {
                var wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement proceedToWishListButton = wait.Until(ExpectedConditions.ElementToBeClickable(navigateToWishListLink));
                proceedToWishListButton?.Click();
                break;
            }
            catch (WebDriverTimeoutException)
            {

                attempt++;
            }
        }


    }
}
