Feature: Inspection
	

Scenario: Inspection without any problems
	Given that user is registred as following
		| id | name | cpf         |
		| 2  | Maria | 46590052085 |
	And the following vehicle is available
		| id | mark      | model | plate  | year | trunkCapacity | hourlyRate |
		| 3  | Chevrolet | Corsa | ABC1234 | 2011 | 500           | 5.0        |
	And a reservation was made
		| vehicleId | userId | starDate         | endDate          | totalPrix |
		| 1         | 1      | 2022-01-01 16:00 | 2022-01-03 18:00 | 250.00    |
	When I make the inspection
		| vehicleId | operatorId | hasDamages | hasScratches | fuelFilled | carCleaned |
		| 1         | 1          | false      | false        | true       | true       |
	Then the reservation total prix will be
		| totalPrix |
		| 250.00    |

Scenario: Inspection with some problems
	Given that user is registred as following
		| id | name | cpf         |
		| 3  | Jose | 46590052085 |
	And the following vehicle is available
		| id | mark      | model | plate  | year | trunkCapacity | hourlyRate |
		| 4  | Chevrolet | Corsa | ABC123 | 2012 | 500           | 5.0        |
	And a reservation was made
		| vehicleId | userId | starDate         | endDate          | totalPrix |
		| 3         | 4      | 2022-01-01 16:00 | 2022-01-03 18:00 | 250.00    |
	When I make the inspection
		| vehicleId | operatorId | hasDamages | hasScratches | fuelFilled | carCleaned |
		| 1         | 1          | false      | true         | true       | false      |
	Then the reservation total prix will be
		| totalPrix |
		| 422.50    |