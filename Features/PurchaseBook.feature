Feature: Purchase Book from Bookworm Website

Make a Boook Purchase

@BookWormBookStore
Scenario: Purchase a book from Bookworm website
    Given I am on the Bookworm website
    When I navigate to the Categories Page
    And I add a book to the cart
    And I view the cart and proceed to Checkout
    And I fill in the checkout form and place an order
    Then I validate that the order is successful
    
