@Login
Feature: Education

A short summary of the feature

Background: 
	Given I am on the login page
    And I enter "ajvmvp@gmail.com" and "4335123"

Scenario: Successfully add a Education
	When I enter Education details as '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>'
	Then I should see the details including '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>'

Examples: 
	| University | Country   | Title | Degree        | Graduation Year |
	| UNSW       | Australia | PHD   | Post Graduate |            2025 |
	| UTS        | Australia | M.A   | Masters       |            2021 |
	| UTS        | Australia | B.A   | Bachelors     |            2019 |

Scenario: Fail adding education with empty title field
	When I enter Education details as '<University>', '<Country>', '', '<Degree>', '<Graduation Year>'
	Then I should see enter education details message

Examples: 
	| University | Country   | Title | Degree        | Graduation Year |
	| UNSW       | Australia |       | Post Graduate |            2025 |

Scenario: Enter a large value in the university field
	When I enter Education details as '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>'
	Then I should not see data added with '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>'

Examples: 
	| University | Country   | Title | Degree        | Graduation Year |
	| jhgjhjhkhyttggvhjgvjhgjhhhhjbhkhjknjnjbnmjnkjh     | Australia | B.A     | Post Graduate |            2025 |


Scenario: Fail adding education with duplicate data
	When I enter Education details as '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>'
	And I enter Education details as '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>'
	Then I should see duplicate Education data message
Examples: 
	| University | Country   | Title | Degree        | Graduation Year |
	| UNSW       | Australia | M.A     | Post Graduate |            2025 |
	

Scenario: Edit an existing Education
	When I enter Education details as '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>'
	And I edit Education details as
	| University | Country   | Title | Degree        | Graduation Year |
	| UTS        | Australia | M.A   | Post Graduate |            2025 |
	Then I should see the updated education with university as
	| University |
	| UTS        |
Examples: 
	| University | Country   | Title | Degree        | Graduation Year |
	| UNSW       | Australia | PHD   | Post Graduate |            2025 |


Scenario: Delete an existing Education
	When I enter Education details as '<University>', '<Country>', '<Title>', '<Degree>', '<Graduation Year>'
	And I delete added Education
	Then I should see the Education field removed
Examples: 
	| University | Country   | Title | Degree        | Graduation Year |
	| UNSW       | Australia | PHD   | Post Graduate |            2025 |
