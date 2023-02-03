Feature: Cart
In order to make a profit from eshop
cart feature must works


Scenario: One produtct in a cart
	Given user is logged in
		And user is on Phones category
	When user select first phone
		And user put goods in cart
		And user confirms confirmation message
		And user navigates to cart
	Then user can see his products in cart page

Scenario: Multiple produtct in a cart
	Given user is logged in
		And user is on Phones category
	When user select first phone
		And user select second phone
		And user put goods in cart
		And user confirms confirmation message
		And user navigates to cart
	Then user can see his products in cart page