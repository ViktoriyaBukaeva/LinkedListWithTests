Feature: MyLinkedList
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](ForListSpecFlowProject/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Adding a value to the end
	Given Create List:
| Numbers |
|    1    |
|    2    |
|    3    |
	When add 4 to list
	Then List must be
| Numbers |
|    1    |
|    2    |
|    3    |
|    4    |

Scenario: Add to empty
	Given Create empty list
	When add 4 to list
	Then List must be
| Numbers |
|    4    |

