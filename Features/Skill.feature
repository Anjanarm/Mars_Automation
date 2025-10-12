@Login
Feature: Skill

A short summary of the feature

Background: 
	Given I am on the login page
    And I enter "anjanarmaus@outlook.com" and "123123"

Scenario: Successfully add a skill
	When I enter skill as "Coding" and level as "Beginner"
	Then I should see the new skill added

Scenario: Fail adding skill with empty skill field
	When I enter skill as "" and level as "Beginner" 
	Then I should see enter skill details message

Scenario: Fail adding skill with empty skill level field
	Given I am on the homepage
	When I enter skill as "Painting" and level as ""
	Then I should see enter skill details message

Scenario: Fail adding skill with duplicate data
	When I enter skill as "Testing" and level as "Expert"
	And I enter skill as "Tetsing" and level as "Expert"
	Then I should see duplicate skill data message

Scenario: Edit an existing skill
	When I enter skill as "Gardening" and level as "Expert"
	And I enter new skill
	Then I should see the updated skill

Scenario: Delete an existing skill
	When I enter skill as "Music" and level as "Beginner"
	And I delete added skill data
	Then I should see the skill field removed
