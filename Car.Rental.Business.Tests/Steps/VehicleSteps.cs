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
    public class VehicleSteps : IClassFixture<Fixture>
    {
        private Fixture _fixture;
        ReturnModel result;

        public VehicleSteps(Fixture fixture)
        {
            _fixture = fixture;
            result = new ReturnModel();
        }

        [Given(@"the following vehicle is available")]
        public async Task GivenTheFollowingVehicleIsAvailable(Table table)
        {
            var vehicle = table.CreateInstance<Vehicle>();
            await _fixture.VehicleContext.AddAsync(vehicle);
            await _fixture.VehicleContext.SaveChangesAsync();
        }
    }
}
