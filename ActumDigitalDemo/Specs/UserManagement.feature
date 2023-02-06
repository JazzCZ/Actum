Feature: UserManagement
In order to use account on eshop
registration and login must works

Scenario: New user is able to sing up
	Given user is on shop homepage
	When user use sing up in header
		And user fill new username
		And user fill new password
		And user confirm sing up
	Then user can see successful sign up

Scenario: Existing user is able to log in
	Given user is on shop homepage
	When user click on login button
		And user fill username
		And user fill password
		And user click on log in
	Then user is logged in