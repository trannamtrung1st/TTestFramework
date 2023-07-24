Feature: Create product

![Create product](https://cdn.shopify.com/s/files/1/0070/7032/files/new-product-development-process.jpg?v=1600652722)

Allow user to create a product on the web application

Link to a feature: [CreateProduct](TTestFramework.Specs.UI/Features/CreateProduct.feature)

**Note**: your can add any MD compatible content here

@T0001
Scenario: Create a product with empty name
	Given the name is empty string
	And the unit price is 1000
	When user clicks on submit
	Then the button should be disabled
	And an error message displays with content "Product name is required"

	
@T0002
Scenario: Create a product with correct information
	Given the name is "Television"
	And the unit price is 1000
	When user clicks on submit
	Then the a success message displays with content "Created product successfully"