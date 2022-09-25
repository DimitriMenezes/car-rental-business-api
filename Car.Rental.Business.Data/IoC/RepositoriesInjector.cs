using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Data.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;


namespace Car.Rental.Business.Data.IoC
{
    public static class RepositoriesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddScoped<IClientReadOnlyRepository, ClientReadOnlyRepository>();
            services.AddScoped<IInspectionRepository, InspectionRepository>();
            services.AddScoped<IVehicleReadOnlyRepository, VehicleReadOnlyRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
        }
    }
}
