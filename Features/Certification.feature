@Login
Feature: Certification

A short summary of the feature

Background: 
	Given I am on the login page
    And I enter "anjanarmaus@outlook.com" and "123123"

Scenario: Successfully add a Certification
	Given I load all certification details from "CertificationTestData.json" for "ValidCertification"
	When I add all certification entries
	Then I should see all the details

Scenario: Fail adding certification with empty from field
	Given I load all certification details from "CertificationTestData.json" for "InvalidCertification"
	When I add all certification entries
	Then I should see error message

Scenario: Fail adding certification with duplicate data
	Given I load all certification details from "CertificationTestData.json" for "DuplicateData"
	When I add all certification entries
	Then I should see duplicate certification data message

Scenario: Edit an existing Certification
	Given I load all certification details from "CertificationTestData.json" for "EditData"
	When I add the original entry
	And I edit with updated entry
	Then I should see the updated certification
	
Scenario: Delete an existing Certification
	Given I load all certification details from "CertificationTestData.json" for "DeleteCertification"
	When I add all certification entries
	And I delete added Certification
	Then I should see the certification field removed
