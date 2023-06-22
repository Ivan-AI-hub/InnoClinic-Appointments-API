using AppointmentsAPI.Application;
using AppointmentsAPI.Application.Abstraction;
using AppointmentsAPI.Domain.Interfaces;
using AppointmentsAPI.Persistence;
using AppointmentsAPI.Persistence.Repositories;
using AppointmentsAPI.Presentation.Consumers;
using AppointmentsAPI.Web.Settings;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using SharedEvents.Models;
using System.Reflection;

namespace AppointmentsAPI.Web.Extensions
{
    public static class ServiceExtencions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration, string connectionStringSectionName)
        {
            var connection = configuration.GetConnectionString(connectionStringSectionName);
            services.AddDbContext<AppointmentsContext>(options =>
                                options.UseNpgsql(connection,
                                b => b.MigrationsAssembly(typeof(AppointmentsContext).Assembly.GetName().Name)));
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IServiceService, ServiceService>();
        }
        public static void ConfigureLogger(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, string elasticUriSection)
        {
            services.AddSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration.Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration[elasticUriSection]))
                    {
                        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}-{environment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                        AutoRegisterTemplate = true,
                        NumberOfShards = 2,
                        NumberOfReplicas = 1
                    })
                    .Enrich.WithProperty("Environment", environment.EnvironmentName)
                    .ReadFrom.Configuration(configuration);
            });
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                           Name = "Bearer",
                        },
                        new List<string>()
                    }
                });
                s.UseDateOnlyTimeOnlyStringConverters();
            });
        }

        public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration, string massTransitSettingsName)
        {
            var settings = configuration.GetSection(massTransitSettingsName).Get<MassTransitSettings>();
            services.AddMassTransit(x =>
            {
                x.AddConsumersFromNamespaceContaining<ServiceUpdatedConsumer>();
                x.AddConsumeObserver<ConsumeObserver>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(settings.Host, settings.VirtualHost, h =>
                    {
                        h.Username(settings.UserName);
                        h.Password(settings.Password);
                    });
                    cfg.AddRawJsonSerializer();
                    cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(true));
                });
            });
        }
    }
}
