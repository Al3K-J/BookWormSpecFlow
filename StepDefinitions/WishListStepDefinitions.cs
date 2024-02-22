using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookWormSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class WishListStepDefinitions
    {
        private IWebDriver driver;
        
        private string randomWishListTitle;

        public WishListStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;   

        } 

      

        [When(@"I pick a book and add it to Wishlist")]
        public void WhenIPickABookAndAddItToWishlist()
        {
            var randomBookTitle = CategoriesPage.GetRandomBookTitle(driver);
            CategoriesPage.ClickOnBookByTitle(driver,randomBookTitle);
            BookDetailsPage.ClickAddToWishlist(driver);

        }

        [When(@"I navigate to the Wishlist")]
        public void WhenINavigateToTheWishlist()
        {
            BookDetailsPage.ProceedToWishlist(driver);
        }

        [When(@"I edit the title of the book")]
        public void WhenIEditTheTitleOfTheBook()
        {
            string randomWishListtitle = TestData.TestData.GetWishListTitle();
            WishListPage.AddNewWishlistTitle(driver, randomWishListtitle);
        }

        [Then(@"I validate that the book is successfully added to the Wishlist")]
        public void ThenIValidateThatTheBookIsSuccessfullyAddedToTheWishlist()
        {
            WishListPage.ValidateThatBookIsAddedToWIshList(driver);
        }

        [Then(@"I validate that the title is successfully edited")]
        public void ThenIValidateThatTheTitleIsSuccessfullyEdited()
        {
            WishListPage.ValidateThatBookTitleIsEdited(driver, randomWishListTitle);
        }

    }
}