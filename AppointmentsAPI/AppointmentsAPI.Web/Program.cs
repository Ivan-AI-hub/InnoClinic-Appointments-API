using AppointmentsAPI.Application.Mappings;
using AppointmentsAPI.Application.Validators;
using AppointmentsAPI.Presentation.Controllers;
using AppointmentsAPI.Web.Extensions;
using AppointmentsAPI.Web.Middlewares;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureLogger();
builder.Services.ConfigureSqlContext(builder.Configuration, "DefaultConnection");
builder.Services.ConfigureMassTransit(builder.Configuration, "MassTransitSettings");
builder.Services.ConfigureRepositories();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureServices();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddControllers().AddApplicationPart(typeof(AppointmentController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile));
builder.Services.AddValidatorsFromAssemblyContaining<CreateAppointmentValidator>();
builder.Services.AddDateOnlyTimeOnlyStringConverters();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
