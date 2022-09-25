using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Services.Abstract;
using Car.Rental.Business.Services.Model;
using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car.Rental.Business.Services.Concrete
{
    public class ContractService : IContractService
    {
		private readonly IReservationRepository _reservationRepository;
		private readonly IVehicleReadOnlyRepository _vehicleReadOnlyRepository;
		private IConverter _converter;
		public ContractService(IReservationRepository reservationRepository, IVehicleReadOnlyRepository vehicleReadOnlyRepository, IConverter converter)
        {
			_reservationRepository = reservationRepository;
			_vehicleReadOnlyRepository = vehicleReadOnlyRepository;
			_converter = converter;
		}

        public async Task<byte[]> GenerateContract(int reservationId)
        {
			var reservation = await _reservationRepository.GetById(reservationId);
			var vehicle = await _vehicleReadOnlyRepository.GetById(reservation.VehicleId);

			var contractModel = new ContractModel
			{
				ClientCpf = "123456789",
				ClientName = "Dimitri Carvalho",
				CurrentDate = DateTime.Now,
				Mark = "Ford",
				Model = "Fiesta",
				Plate = "JBL123",
				Year = 2015
			};

			var html = GetHTMLString(contractModel);

			var globalSettings = new GlobalSettings
			{				
				Orientation = Orientation.Portrait,
				PaperSize = PaperKind.A4,
			};

			var objectSettings = new ObjectSettings
			{				
				HtmlContent = html,
			};

			var pdf = new HtmlToPdfDocument()
			{
				GlobalSettings = globalSettings,
				Objects = { objectSettings }
			};
			;
			var result = _converter.Convert(pdf);
			return result;
        }

        public string GetHTMLString(ContractModel model)
        {            
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                         <html>
	                        <head>
		                        <h1>Rent a Car - Contract Agreement</h1>
	                        </head>
	                        <body>		
		                        <div>
			                        Brazil, {0}
		
			                        I, {1}, CPF Number {2} holder, would like to confirm the rental of the following vehicle:
		                            </div>
		                            <table align='center'>
			                            <tr>				                            
				                            <th>Model</th>
				                            <th>Mark</th>
				                            <th>Year</th>
				                            <th>Plate</th>
			                            </tr>", model.CurrentDate.ToShortDateString(), model.ClientName, model.ClientCpf);

                sb.AppendFormat(@"<tr>
									<td>{0}</td>
									<td>{1}</td>
									<td>{2}</td>
									<td>{3}</td>									
								 </tr>
							</table>", model.Model, model.Mark, model.Year, model.Plate);
            

            sb.Append(@"I agree that in case of inspection problems like 
		                1- vehicle not cleaned
		                2- vehicle not filled properly with fuel
		                3- damages 
                        4- scratches
		                a 30% penalty per problem will be increased on total value to be payed.
				
		                ________________
		                Signature of Client
		
	                </body>
                </html>");
            return sb.ToString();
        }
    }
}
