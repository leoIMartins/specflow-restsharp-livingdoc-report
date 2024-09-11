Feature: Test scenarios of API https://jsonplaceholder.typicode.com/posts

  @posts
  @get_by_id
  Scenario: View post by ID
    Given I send a GET request by ID
    Then the response status code should be "200"
    And the response body should contain existing user data

  @posts
  @post
  Scenario: Create a new post
    Given I send a POST request
    Then the response status code should be "201"
    And the response body should contain new user data