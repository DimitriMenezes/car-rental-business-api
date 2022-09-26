Feature: Simulation
	

Scenario: Car Rental Simulation
	Given the following vehicle is available
		| id | mark      | model | LicensePlate | Year | TrunkCapacity | HourlyRate |
		| 1  | Chevrolet | Corsa | ABC123       | 2012 | 500           | 5.0        |
	When I make a simulation for this vehicle
		| VehicleId | StartDate         | EndDate          |
		| 1         | 2022-01-01 16:00 | 2022-01-03 22:00 |
	Then the result will be "270.00"