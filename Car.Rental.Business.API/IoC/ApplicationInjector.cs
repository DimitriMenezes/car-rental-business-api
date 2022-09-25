using Car.Rental.Business.Data.IoC;
using Car.Rental.Business.Services.IoC;
using Car.Rental.Business.Services.Settings;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Car.Rental.Business.API.IoC
{
    public static class ApplicationInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {           
            RepositoriesInjector.RegisterServices(services);
            ServicesInjector.RegisterServices(services);


            var key = Encoding.ASCII.GetBytes(SecuritySettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }
    }
}
