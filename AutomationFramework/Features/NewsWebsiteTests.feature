Feature: NewsWebsiteTests
	In order to see the different functions of a Browser and report it to a wider audience
	the following set of scenarios are created

@Browser:Chrome
@Browser:Firefox
Scenario: Launch Google News and Display the headlines
	Given I launch the home page for 'Google News'

	When I retrieve all the headlines for the day

@Browser:Chrome
@Browser:Firefox
Scenario: Launch Yahoo News and Display the headlines
Given I launch the home page for 'Yahoo News'

	When I retrieve all the headlines for the day
