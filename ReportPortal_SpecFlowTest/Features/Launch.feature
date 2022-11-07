Feature: Launch
	As a authenticated user
	I want to go to launches dashboard
	And check the execution results
	For a specific launch number

Scenario Outline: LaunchResultsAsExpected
	Given User is authenticated
	When User goes to the launches board
	Then The launch matches the following columns: '<LaunchNumber>' '<Total>' '<Passed>' '<Failed>'
	
	Examples:
	| LaunchNumber | Total | Passed | Failed |
	| 10           | 30    | 30     |        |
	| 9            | 25    | 20     | 5      |
	| 8            | 20    | 10     | 8      |
