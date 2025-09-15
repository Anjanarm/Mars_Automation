Feature: Language

A short summary of the feature


Scenario: Successfully add a language
	Given I am on the homepage
	When I enter language and language level
	Then I should see the new language added

Scenario: Fail adding language with empty language field
	Given I am on the homepage
	When I enter language level and leave language empty
	Then I should see enter details message

Scenario: Fail adding language with empty language level field
	Given I am on the homepage
	When I enter language and leave language level empty
	Then I should see enter details message

Scenario: Fail adding language with duplicate data
	Given I am on the homepage
	When I enter existing language
	Then I should see duplicate data message

Scenario: Edit an existing language
	Given I am on the homepage
	When I enter new details
	Then I should see the updated data

Scenario: Delete an existing language
	Given I am on the homepage
	When I delete a language data
	Then I should see the language field removed

