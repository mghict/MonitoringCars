
using API.IOC;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System.Reflection;

static void AutoRegisterAppServices(IServiceCollection services,IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("AppConnectionString");
    services.AddDbContext<Infrastructure.Data.AppDbContext>((serviceProvider, dbContextOptionsBuilder) =>
    {
        //var databaseOptions = serviceProvider.GetService<IOptions<Web.API.Common.DatabaseOptions>>()!.Value;

        //dbContextOptionsBuilder
        //    .EnableSensitiveDataLogging()
        //    .UseSqlServer(databaseOptions.ConnectionString, sqlserverAction =>
        //    {
        //        sqlserverAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
        //        sqlserverAction.CommandTimeout(databaseOptions.CommandTimeout);
        //    });

        //dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
        //dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        dbContextOptionsBuilder.UseSqlServer(connectionString,a=>a.CommandTimeout(180));
    });

    services.AddScoped<Domain.IUnitOfWork, Infrastructure.Data.UnitOfWork>();

    //services.AddScoped<Common.Data.IAppRepository<,>, Infrastructure.Data.AppRepository<,>>();
    //services.AddScoped<Domain.Entities.IRecievedDataRepository, Infrastructure.Data.Repositories.RecievedDataRepository>();
    services.AddSingleton<Application.RecievedData.Validation.RecievedDataCreateValidation>();
    services.AddScoped<Service.Services.RecievedDataService>();
    ///******************************************
    /// AutoMapper
    ///******************************************
    services.AddAutoMapper((typeof(Application.RecievedData.Mapper.RecievedDataMapper)).GetTypeInfo().Assembly);
    ///******************************************
    /// MediatR
    ///******************************************
    services.AddMediatR((typeof(Application.RecievedData.Commands.RecievedDataCreateCommand)).GetTypeInfo().Assembly);
}


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
AutoRegisterAppServices(builder.Services,builder.Configuration);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
