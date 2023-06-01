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
            services.AddScoped<IResultRepository, ResultRepository>();

            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IResultService, ResultService>();

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IServiceService, ServiceService>();
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
                x.AddConsumersFromNamespaceContaining<ServiceNameUpdatedConsumer>();
                x.AddConsumeObserver<ConsumeObserver>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(settings.Host, settings.VirtualHost, h =>
                    {
                        h.Username(settings.UserName);
                        h.Password(settings.Password);
                    });
                    cfg.AddRawJsonSerializer();
                    cfg.ConfigureEndpoints(context);
                });
            });
        }

        public static void ConfigureLogger(this IServiceCollection services)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.Console()
                .CreateLogger();
            services.AddLogging(builder =>
            {
                builder.AddSerilog(logger);
            });
        }
    }
}
