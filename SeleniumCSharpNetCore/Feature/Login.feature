Feature: Login
	Check if login functionality works

@mytag
Scenario: Login Application
	Given I navigate to application
	And I click the SignIn link
	And I enter username and password
		| UserName					 | Password |
		| dnsvikas.wins@gmail.com    | Password |
	And I click SignIn Button
	Then I should see user logged in to the application
