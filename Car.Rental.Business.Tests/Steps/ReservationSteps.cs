using Car.Rental.Business.Domain.Entities;
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
    public class ReservationSteps
    {
        protected Fixture _fixture;
        protected IReservationService _reservationService;
        protected ReturnModel _returnModel;
        
        public ReservationSteps(Fixture fixture)
        {
            _fixture = fixture;
            _reservationService = fixture._reservationService;
            _returnModel = new ReturnModel { Data = ""};
        }

        [Given(@"that I'm registred as following")]
        public void GivenThatIMRegistredAsFollowing(Table table)
        {
            
        }
        
        [When(@"I make a reservation for this vehicle")]
        public async Task WhenIMakeAReservationForThisVehicle(Table table)
        {
            var reservationModel = table.CreateInstance<ReservationModel>();
           
            _returnModel = await _reservationService.AddReservation(reservationModel);            
        }
        
        [Then(@"the following reservation will be saved")]
        public async Task ThenTheFollowingReservationWillBeSaved(Table table)
        {
            var expectedReservation = table.CreateInstance<Reservation>();

            ReservationModel result = _returnModel.Data as ReservationModel;
            Assert.Equal(expectedReservation.TotalPrix, result.TotalPrix);
        }
    }
}
