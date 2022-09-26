Feature: Reservation

Scenario: Reservation sucessfully
	Given that I'm registred as following
		| Id | Name | Cpf         |
		| 1  | Joao | 46590052085 |
	And the following vehicle is available
		| Id | Mark      | Model | Plate   | Year | TrunkCapacity | HourlyRate |
		| 2  | Chevrolet | Corsa | ABC1234 | 2013 | 500           | 5.0        |
	When I make a reservation for this vehicle
		| VehicleId | ClientId | StartDate        | EndDate          |
		| 2         | 1        | 2022-01-01 16:00 | 2022-01-03 22:00 |
	Then the following reservation will be saved
		| VehicleId | ClientId | StartDate        | EndDate          | TotalPrix |
		| 2         | 1        | 2022-01-01 16:00 | 2022-01-03 18:00 | 270.00    |