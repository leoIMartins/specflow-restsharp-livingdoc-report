Feature: Test scenarios of API https://jsonplaceholder.typicode.com/users

  @users
  @patch
  Scenario: Update an user
    Given I send a PATCH request
    Then the response status code should be "200"
    And the response body should contain the updated user data