Feature: LinkedListAllMethods

A short summary of the feature

@tag1
Scenario: Add to Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 0       |
		| 2       |
		| 3       |
	When Add -5 to Linkedlist
	Then Linkedlist must be:
		| Numbers  |
		| 0,2,3,-5 |

Scenario: Add to empty Linkedlist
	Given Create empty Linkedlist		
	When Add 0 to Linkedlist
	Then Linkedlist must be:
		| Numbers  |
		|    0     |

Scenario: Add first element in empty Linkedlist
	Given Create empty Linkedlist		
	When Add element 0 to the beginning
	Then Linkedlist must be:
		| Numbers  |
		|    0     |

Scenario: Add first element in Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 0       |
		| 2       |
		| 3       |
	When Add element -5 to the beginning
	Then Linkedlist must be:
		| Numbers  |
		| -5,0,2,3 |

Scenario: Add element by index to Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 0       |
		| 2       |
		| 3       |
	When Adding element by index 0 value 1
	Then Linkedlist must be:
		| Numbers  |
		| 1,0,2,3  |

Scenario: Add last element by index to Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 0       |
		| 1       |
		| 2       |
		| 4       |
	When Adding element by index 3 value 3
	Then Linkedlist must be:
		|   Numbers   |
		|  0,1,2,3,4  |

Scenario: Add element by index in empty Linkedlist
	Given Create empty Linkedlist
	When Adding element by index 0 value 1
	Then Linkedlist must be:
		| Numbers |
		|    1    |

Scenario: Remove first element from the Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 0       |
		| 1       |
		| 2       |
		| 3       |
	When Remove first element from the Linkedlist
	Then Linkedlist must be:
		| Numbers |
		|  1,2,3  |

Scenario: Remove a single element from the Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 0       |
	When Remove first element from the Linkedlist
	Then Linkedlist must be null

Scenario: Remove first element from the empty Linkedlist
	Given Create empty Linkedlist		
	When Remove first element from the Linkedlist
	Then Linkedlist must be null

Scenario: Remove last element from the Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 1       |
		| 2       |
		| 3       |
	When Remove last element from the Linkedlist
	Then Linkedlist must be:
		| Numbers |
		|   1,2   |

Scenario: Remove element ByIndex from the Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 1       |
		| 2       |
		| 3       |
	When Remove element by index 1 from the Linkedlist
	Then Linkedlist must be:
		| Numbers |
		|   1,3   |

Scenario: Remove element By single Index from the Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 1       |
	When Remove element by index 0 from the Linkedlist
	Then Linkedlist must be null

Scenario: Remove all elements from the end Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 1       |
		| 2       |
	When Remove 2 elements from the end Linkedlist
	Then Linkedlist must be null

Scenario: Remove 1 last element from the end Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 1       |
		| 2       |
		| 3       |
	When Remove 1 elements from the end Linkedlist
	Then Linkedlist must be:
	    | Numbers |
	    |   1,2   |

Scenario: Remove 1 element from the start Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 1       |
		| 2       |
		| 3       |
	When Remove 1 element from the start Linkedlist
	Then Linkedlist must be:
	    | Numbers |
	    |   2,3   |

Scenario: Remove all elements from the start Linkedlist
	Given Create Linkedlist:
		| Numbers |
		| 1       |
		| 2       |
	When Remove 2 element from the start Linkedlist
	Then Linkedlist must be null

Scenario: Remove N Elements By Index
	Given Create Linkedlist:
		| Numbers |
		| 1       |
		| 2       |
		| 3       |
		| 4       |
	When Remove <Elements> elements ByIndex <Index> from the Linkedlist
	Then Linkedlist must be <Result>
Examples: 
| Index | Elements | Result |
| 2     | 2        | 1, 2   |
| 0     | 2        | 3, 4   |







