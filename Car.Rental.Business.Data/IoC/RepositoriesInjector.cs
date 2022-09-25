using Car.Rental.Business.Data.Repositories.Abstract;
using Car.Rental.Business.Data.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;


namespace Car.Rental.Business.Data.IoC
{
    public static class RepositoriesInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleReadOnlyRepository, VehicleReadOnlyRepository>();
        }
    }
}
