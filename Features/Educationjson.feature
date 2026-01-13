Feature: Educationjson

A short summary of the feature

Background: 
	Given I am on the login page
    And I enter "anjanarmaus@outlook.com" and "123123"

Scenario: Successfully add an Education
	Given I load all Education details from "EducationTestData.json" for "ValidEducation"
	When I add all Education entries
	Then I should see all the Education details

Scenario: Fail adding Education with empty from field
	Given I load all Education details from "EducationTestData.json" for "InvalidEducation"
	When I add all Education entries
	Then I should see an error message

Scenario: Fail adding cer with duplicate data
	Given I load all Education details from "EducationTestData.json" for "DuplicateData"
	When I add all Education entries
	Then I should see duplicate Education data message

Scenario: Edit an existing Education
	Given I load all Education details from "EducationTestData.json" for "EditData"
	When I add the original education entry
	And I edit with updated education entry
	Then I should see the updated education
	
Scenario: Delete an existing Education
	Given I load all Education details from "EducationTestData.json" for "DeleteEducation"
	When I add all Education entries
	And I delete added Education
	Then I should see the education field removed
