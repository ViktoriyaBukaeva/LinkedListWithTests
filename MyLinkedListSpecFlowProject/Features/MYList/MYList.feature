Feature: MYList

A short summary of the feature

@tag1
Scenario: Add to list
	Given Create list:
		| Numbers |
		| 0       |
		| 2       |
		| 3       |
	When Add -5 to list
	Then List mast be:
		| Numbers  |
		| 0,2,3,-5 |

Scenario: Add to empty
	Given Create empty list
	When Add 0 to list
	Then List mast be:
		| Numbers |
		| 0       |

#ПРимеры
#Scenario: Add first element to list
#	Given Create empty list
#	When Add 0 in end of list
#	Then List mast be:
#		| Numbers |
#		| 0       |

	#Then List mast be:
	#| Numbers |
	#|  <qqq>  |
	#Examples:
	#|   qqq   |
	#| 1,2,3,4 |
	# Можно оформлять красиво вот так | [1,2,3,4,5] | или как json через 
	# сериалайз и десериалайз.Оформлять как json и конвертить внутри проекта




