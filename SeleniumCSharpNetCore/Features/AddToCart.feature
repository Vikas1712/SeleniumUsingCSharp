Feature: AddToCart
	Simple calculator for adding two numbers

@mytag
Scenario: Add two numbers
	Given I navigate to application
	And I click the SignIn link
	And I enter username and password
		| UserName					 | Password |
		| dnsvikas.wins@gmail.com    | Password |
	And I click SignIn Button
	#And I navigate to application
	Then I should see user logged in to the application

	