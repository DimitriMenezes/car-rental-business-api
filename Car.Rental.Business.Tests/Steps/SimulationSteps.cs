using Car.Rental.Business.Domain.Entities.Vehicles;
using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Model;
using Car.Rental.Business.Tests.Data;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Car.Rental.Business.Tests.Steps
{
    [Binding]
    public class SimulationSteps : IClassFixture<Fixture>
    {
        private Fixture _fixture;
        private IRentalSimulationService _simulationService;
        ReturnModel result;
        

        public SimulationSteps(Fixture fixture)
        {
            _fixture = fixture;
            _simulationService = fixture._simulationService;
            result = new ReturnModel();            
        }
       
        [When(@"I make a simulation for this vehicle")]
        public async Task WhenIMakeASimulationForThisVehicle(Table table)
        {
            var model = table.CreateInstance<SimulationModel>();
            result = await _simulationService.SimulateRentalPrice(model);
        }
        
        [Then(@"the result will be ""(.*)""")]
        public void ThenTheResultWillBe(Decimal p0)
        {
            Assert.Equal(p0, result.Data);            
        }
    }
}
