Feature: Answers

@mytag
Scenario: The answer with the highest vote gets to the top
	Given there is a question with "What's your favorite colour?" with the answers
	| Answer         | Vote |
	| Red            | 1    |
	| Cucumber Green | 1    |
	When you upvote answer "Cucumber Green"
	Then the answer "Cucumber Green" should be on top

Scenario: The answer with the highest vote gets to the top 2
	Given there is a question with "What's your favorite colour?" with the answers
	| Answer         | Vote |
	| Red            | 3    |
	| Cucumber Green | 1    |
	When you upvote answer "Cucumber Green"
	Then the answer "Red" should be on top

Scenario: The answer with the highest vote gets to the top 1
	Given there is a question with "What's your favorite colour?" with the answers
	| Answer         | Vote |
	| Red            | 3    |
	| Cucumber Green | 3    |
	When you upvote answer "Cucumber Green"
	Then the answer "Cucumber Green" should be on top

Scenario: foo bar
	Given there is no questions
	When you upvote answer "Cucumber Green"
	Then an exception should be thrown

