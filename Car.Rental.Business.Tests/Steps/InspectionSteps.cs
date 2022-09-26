using Car.Rental.Business.Domain.Entities;
using Car.Rental.Business.Domain.Entities.Vehicles;
using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Model;
using Car.Rental.Business.Tests.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Car.Rental.Business.Tests.Steps
{
    [Binding]
    public class InspectionSteps : IClassFixture<Fixture>
    {
        private Fixture _fixture;
        private IInspectionService _inspectionService;
        private IReservationService _reservationService;        
        private ReturnModel result = new ReturnModel();
        private int reservationId = 1;

        public InspectionSteps(Fixture fixture)
        {
            _fixture = fixture;
            _inspectionService = fixture._inspectionService;
            _reservationService = fixture._reservationService;
        }

        [Given(@"that user is registred as following")]
        public void GivenThatUserIsRegistredAsFollowing(Table table)
        {
            
        }
        
        [Given(@"a reservation was made")]
        public async Task GivenAReservationWasMade(Table table)
        {
            var reservation = table.CreateInstance<ReservationModel>();
            reservation.Id = reservationId;
            var result = await _reservationService.AddReservation(reservation);
            Assert.NotNull(result.Data);            
        }
        
        [When(@"I make the inspection")]
        public async Task WhenIMakeTheInspection(Table table)
        {
            var inspection = table.CreateInstance<InspectionModel>();
            inspection.ReservationId = reservationId;
            var resultInspection = await _inspectionService.MakeInspection(inspection);
            Assert.NotNull(resultInspection.Data);
            result = await _reservationService.GetReservation(reservationId);
        }
        
        [Then(@"the reservation total prix will be")]
        public void ThenTheReservationTotalPrixWillBe(Table table)        
        {
            var totalPrixExpected = Convert.ToDecimal(table.Rows[0].Values.FirstOrDefault());
            var totalPrixReceived = (result.Data as ReservationModel).TotalPrix;
            Assert.Equal(totalPrixExpected, totalPrixReceived);
        }
    }
}
