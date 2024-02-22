Feature: WishList Functionality

Edit Perosnal WIshList Title

@BookWormBookStore
Scenario: Add a book to the Wishlist and edit title
    Given I am on the Bookworm website
    When I navigate to the Categories Page
    And I pick a book and add it to Wishlist
    And I navigate to the Wishlist
    And I edit the title of the book
    Then I validate that the book is successfully added to the Wishlist
    And I validate that the title is successfully edited

    