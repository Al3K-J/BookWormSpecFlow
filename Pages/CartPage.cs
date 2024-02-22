using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWormSpecFlow.TestData;

public static class CartPage
{
    private const string ProceedToCheckoutCssSelector = ".wc-proceed-to-checkout a.checkout-button";

    private static By firstNameLocator = By.Id("billing_first_name");
    private static By lastNameLocator = By.Id("billing_last_name");
    private static By companyNameLocator = By.Id("billing_company");
    private static By streetAddres1Locator = By.Id("billing_address_1");
    private static By streetAddres2Locator = By.Id("billing_address_2");
    private static By townCityLocator = By.Id("billing_city");
    private static By postCodeLocator = By.Id("billing_postcode");
    private static By phoneNumLocator = By.Id("billing_phone");
    private static By emailAddresLocator = By.Id("billing_email");
    private static By countryRegionLocator = By.Id("select2-billing_country-container");
    private static By countryStateResultsLocator = By.CssSelector("ul.select2-results__options li");
    private static By stateCountyLocator = By.Id("select2-billing_state-container");
    private static By directBankTransfer = By.Id("payment_method_bacs");
    private static By checkPayment = By.Id("payment_method_cheque");
    private static By cashOnDilivery = By.Id("payment_method_cod");
    private static By placeOrderButton = By.Id("place_order");
    public static void ProceedToCheckout(IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement proceedToCheckoutLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(ProceedToCheckoutCssSelector)));
        proceedToCheckoutLink.Click();
    }

    public static void FillBillingForm(IWebDriver driver)
    {
        List<YourTestDataClass> testDataList = TestData.GetTestDataFromCsv("CheckOutData.csv", 1);

        foreach (var testData in testDataList)
        {
            driver.FindElement(firstNameLocator).SendKeys(testData.FirstName);
            driver.FindElement(lastNameLocator).SendKeys(testData.LastName);
            if (!string.IsNullOrEmpty(testData.CompanyName))
            {
                driver.FindElement(companyNameLocator).SendKeys(testData.CompanyName);
            }

            driver.FindElement(streetAddres1Locator).SendKeys(testData.StreetAddress1);
            driver.FindElement(streetAddres2Locator).SendKeys(testData.StreetAddress2);
            SelectRandomCounty(driver);
            driver.FindElement(townCityLocator).SendKeys(testData.TownCity);
            driver.FindElement(postCodeLocator).SendKeys(testData.PostCode);
            driver.FindElement(phoneNumLocator).SendKeys(testData.Phone);
            driver.FindElement(emailAddresLocator).SendKeys(testData.Email);
            break;
        }
    }

    private static void SelectRandomCountry(IWebDriver driver)
    {
        driver.FindElement(countryRegionLocator).Click();

        IList<IWebElement> results = driver.FindElements(countryStateResultsLocator);

        Random random = new Random();
        int index = random.Next(results?.Count ?? 0);
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", results?[index]);
        results?[index]?.Click();

    }


    public static void SelectRandomCounty(IWebDriver driver)
    {
        driver.FindElement(stateCountyLocator).Click();

        IList<IWebElement> results = driver.FindElements(countryStateResultsLocator);

        Random random = new Random();
        int index = random.Next(results?.Count ?? 0);

        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", results?[index]);

        results?[index]?.Click();

    }

    public static void SelectPayment(IWebDriver driver)
    {
        List<By> paymentMethodLocators = new List<By>
            {
              directBankTransfer,
              cashOnDilivery,
              checkPayment
            };

        Random random = new Random();
        int randomIndex = random.Next(paymentMethodLocators.Count);
        driver.FindElement(paymentMethodLocators[randomIndex])?.Click();


    }
    public static void ValidateSuccessfulOrder(IWebDriver driver)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.Url.Contains("/checkout/order-received"));


        string currentUrl = driver.Url;
        Assert.IsTrue(currentUrl.Contains("/checkout/order-received"), "The expected substring is not present in the URL");
    }

    public static void PlaceOrder(IWebDriver driver)
    {
        driver.FindElement(placeOrderButton).Click();


    }

}
