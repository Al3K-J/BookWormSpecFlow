using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWormSpecFlow.StepDefinitions
{
    [Binding]
    public class PurchaseBookStepDefinitions
    {
        private IWebDriver driver;
        public string pageUrl = "https://bookworm.madrasthemes.com/";
        private string randomWishListTitle;

        public PurchaseBookStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

        }



        [When(@"I add a book to the cart")]
        public void WhenIAddABookToTheCart()
        {
            var randomBookTitle = CategoriesPage.GetRandomBookTitle(driver);
            CategoriesPage.ClickOnBookByTitle(driver, randomBookTitle);
            BookDetailsPage.SelectRandomBookOptions(driver);
            BookDetailsPage.ClickAddToCart(driver);
        }

        [When(@"I view the cart and proceed to Checkout")]
        public void WhenIViewTheCartAndProceedToCheckout()
        {
            BookDetailsPage.GoToCart(driver);
            CartPage.ProceedToCheckout(driver);
        }

        [When(@"I fill in the checkout form and place an order")]
        public void WhenIFillInTheCheckoutFormAndPlaceAnOrder()
        {
            CartPage.FillBillingForm(driver);
            CartPage.SelectPayment(driver);
            CartPage.PlaceOrder(driver);
        }

        [Then(@"I validate that the order is successful")]
        public void ThenIValidateThatTheOrderIsSuccessful()
        {
            CartPage.ValidateSuccessfulOrder(driver);
        }

        


    }
}
