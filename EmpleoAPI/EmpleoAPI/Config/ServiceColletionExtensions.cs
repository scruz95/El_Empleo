using EmpleoAPI.DataAccess.DAO;
using EmpleoAPI.Services.Services;
using EmpleoAPI.Services.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmpleoAPI.Config
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IBaseDAO<>), typeof(BaseDAO<>));
            services.AddScoped<ICityDAO, CityDAO>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICityValidator, CityValidator>();
            services.AddScoped<ISellerDAO, SellerDAO>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<ISellerValidator, SellerValidator>();
            return services;
        }
    }
}
