Feature: Inspection

Scenario: Inspection without any problems
	Given that user is registred as following
		| Id | Name  | Cpf         |
		| 2  | Maria | 46590052085 |
	And the following vehicle is available
		| Id | Mark      | Model | Plate   | Year | TrunkCapacity | HourlyRate |
		| 3  | Chevrolet | Corsa | ABC1234 | 2011 | 500           | 5.0        |
	And a reservation was made
		| VehicleId | ClientId | StartDate        | EndDate          | TotalPrix |
		| 3         | 2        | 2022-01-01 16:00 | 2022-01-03 22:00 | 270.00    |
	When I make the inspection
		| vehicleId | operatorId | HasDamages | HasScratches | FuelFilled | VehicleClean |
		| 3         | 1          | false      | false        | true       | true         |
	Then the reservation total prix will be
		| totalPrix |
		| 270.00    |

Scenario: Inspection with some problems
	Given that user is registred as following
		| Id | Name | Cpf         |
		| 3  | Jose | 46590052085 |
	And the following vehicle is available
		| Id | Mark      | Model | Plate  | Year | TrunkCapacity | HourlyRate |
		| 4  | Chevrolet | Corsa | ABC123 | 2012 | 500           | 5.0        |
	And a reservation was made
		| VehicleId | ClientId | StartDate        | EndDate          | TotalPrix |
		| 4         | 3        | 2022-01-01 16:00 | 2022-01-03 22:00 | 270.00    |
	When I make the inspection
		| VehicleId | OperatorId | HasDamages | HasScratches | FuelFilled | VehicleClean |
		| 4         | 1          | false      | true         | true       | false        |
	Then the reservation total prix will be
		| totalPrix |
		| 456.300   |