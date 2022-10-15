using HR.Api.MappingImplementations.MappingConfiguration;
using HR.Api.MappingImplementations.Request;
using HR.Api.MappingImplementations.Response;
using HR.BLL;
using HR.BLL.OAuthServices;
using HR.BLL.SharedServices;
using HR.DAL.Domain;
using HR.DAL.Repository;
using HR.Entities.EnvironmentConfigurations.Implementation;
using HR.Entities.EnvironmentConfigurations.Interface;
using HR.Entities.Interfaces.OAuthServices;
using HR.Entities.Interfaces.Repository;
using HR.Entities.Interfaces.SharedServices;
using HR.Entities.Mapping.MappingConfiguration;
using HR.Entities.Mapping.Request;
using HR.Entities.Mapping.Response;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HR.Api.ExtensionManager
{
    public static class ServiceCollectionExtentions
    {
        public static void AddContextExtentions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddRepositoryConfigurations(this IServiceCollection services)
        {
            // Generic Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<HRDBContext>();
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddHttpClient();

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IVacancyAppliersRepository, VacancyAppliersRepository>();


            // Shared Services
            services.AddScoped<IJwtManager, JWTManager>();
            services.AddScoped<IHelperServices, HelperServices>();
        }

        public static void AddMappingConfigurations(this IServiceCollection services)
        {
            // User
            services.AddScoped<IUserMapperConfiguration, UserMapperConfiguration>();
            services.AddScoped<IUserMappingResponse, UserMappingResponse>();

            // Vacancy
            services.AddScoped<IVacancyMapperConfiguration, VacancyMapperConfiguration>();
            services.AddScoped<IVacancyMappingResponse, VacancyMappingResponse>();
            services.AddScoped<IVacancyMappingRequest, VacancyMappingRequest>(); 
            
            // Vacancy Appliers
            services.AddScoped<IVacancyAppliersMapperConfiguration, VacancyAppliersMapperConfiguration>();
            services.AddScoped<IVacancyAppliersMappingResponse, VacancyAppliersMappingResponse>();
            services.AddScoped<IVacancyAppliersMappingRequest, VacancyAppliersMappingRequest>();

        }
        public static void AddMediatorConfigurations(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatorEntryPoint).Assembly);
        }

        public static void AddEnvironmentVariablesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHelperConfigurations>(configuration.GetSection("HelperConfigurations").Get<HelperConfigurations>());
            services.AddSingleton<IJwtConfiguration>(configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>());
        }

        public static void AddJWTConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;

                var key = configuration.GetValue<string>("JwtConfiguration:Key");
                var issuer = configuration.GetValue<string>("JwtConfiguration:Issuer");
                var audience = configuration.GetValue<string>("JwtConfiguration:Audience");
                var secret = Encoding.UTF8.GetBytes(key);

                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero // to expire token immediatly without clock skew
                };
            });
        }
    }
}
