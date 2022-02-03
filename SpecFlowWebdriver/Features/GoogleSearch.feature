Feature: GoogleSearch

Scenario: Simple search should return result
	Given open search page
	When type cheese and click search
	Then the result should contain Wikipedia