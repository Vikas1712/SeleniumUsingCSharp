Feature: AddToCart
	Simple calculator for adding two numbers


@mytag
Scenario: Validate login functionality for exisitng user
	Given I navigate to application
	And I click the SignIn link
	And I enter username and password
		| UserName					 | Password |
		| dnsvikas.wins@gmail.com    | Password |
	And I click SignIn Button
	#And I navigate to application
	Then I should see user logged in to the application

Scenario: Validate User creation for automationPractice site
	Given I am on automation practice site
	When I create a new account
	Then the account for the user is created