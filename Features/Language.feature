
@Login
Feature: Language

Background: 
	Given I am on the login page
    And I enter "anjanarmaus@outlook.com" and "123123"

Scenario: Successfully add a language
	When I enter "English" and "Fluent"
	Then I should see the new language added

Scenario: Fail adding language with empty language field
	When I enter "" and "Fluent" 
	Then I should see enter details message

Scenario: Fail adding language with empty language level field
	Given I am on the homepage
	When I enter "Germen" and ""
	Then I should see enter details message

Scenario: Fail adding language with duplicate data
	When I enter "French" and "Fluent"
	And I enter "French" and "Basic"
	Then I should see duplicate data message

Scenario: Edit an existing language
	When I enter "Hindi" and "Conversational"
	And I enter new details
	Then I should see the updated data

Scenario: Delete an existing language
	When I enter "Spanish" and "Basic"
	And I delete added language data
	Then I should see the language field removed

