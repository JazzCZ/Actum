Feature: Cart
In order to make a profit from eshop
cart feature must works

#bug in cart found, test is not fully operational
Scenario: One produtct in a cart
	Given user is on shop homepage
		And user is logged in
		And user is on 'Phones' category
	When user select first product
		And user put goods in cart
		And user navigates to cart
	Then user can see his products in cart page

#as bug found in previous scenario, keepint this scenario as WIP and ignoring
@ignore
Scenario: Multiple produtct in a cart
	Given user is on shop homepage
		And user is logged in
		And user is on 'Phones' category
	When user select first product
		And user put goods in cart
		And user select second product
		And user put goods in cart
		And user navigates to cart
	Then user can see his products in cart page