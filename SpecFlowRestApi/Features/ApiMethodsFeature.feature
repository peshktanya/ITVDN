Feature: RestApi testing

Scenario: Get request and receive success response 
	Given connect to db
	And create get request
	When send request
	Then response is success