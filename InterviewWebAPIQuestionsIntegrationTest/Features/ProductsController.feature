Feature: ProductsController
Allows us to do crud operation for the product

@tag1
Scenario: Successfully retrieves a list of products
    Given I have a valid request to retrieve products
    When I call the GetProducts API
    Then I should receive a successful response
    And the response should contain a list of products

  Scenario: No products are available
    Given I have a valid request to retrieve products
    And no products are available
    When I call the GetProducts API
    Then I should receive a successful response
    And the response should contain an empty list

  Scenario: An error occurs while retrieving products
    Given I have a valid request to retrieve products
    And an error occurs while retrieving products
    When I call the GetProducts API
    Then I should receive an error response
