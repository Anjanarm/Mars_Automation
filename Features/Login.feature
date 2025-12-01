
Feature: Login Functionality
  As a user, I want to log in to the application to access restricted content.
  

 Scenario: Perform login
    Given I am on the login page
    And I enter "<username>" and "<password>"
    Then I should see an "<outcome>"

 Examples:
    | username                | password | outcome              |
    | anjanarmaus@outlook.com | 123123   | secure area  |
    | abc@gmail.com           | 123123   | error message |
    | anjanarmaus@outlook.com | invalid  | error message |
    |                         |          | error message |
