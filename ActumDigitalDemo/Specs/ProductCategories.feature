Feature: ProductCategories
In order to have proper goods presentation for customers
product categories must works

Scenario Outline: User is able to browse categories
	Given user is on shop homepage
	When user navigates to '<categoryName>' category
	Then user can see '<productType>'
		And user can see images

 Examples: 
 | categoryName | productType |
 | Phones       | phones      |
 | Laptops      | laptops     |
 | Monitors     | monitors    |