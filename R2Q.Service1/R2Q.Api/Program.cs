
using Microsoft.AspNetCore.OData;
using Serilog;
using Serilog.Formatting.Compact;
using R2Q.Application;
using R2Q.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Google.Api;
using R2Q.Application.Contracts.Persistence;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Async(x => x.Console(new CompactJsonFormatter()))
    .CreateBootstrapLogger();

Log.Information("Starting up");
var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
// Add services to the container.
builder.Host.UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((builderContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables();
            });

builder.Host.UseSerilog();
builder.Services.AddApiVersioning(config =>
{
    // Specify the default API Version as 1.0
    config.DefaultApiVersion = new ApiVersion(1, 0);

    // If the client hasn't specified the API version in the request, use the default API version number
    config.AssumeDefaultVersionWhenUnspecified = true;

    // Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;
});
builder.Services.AddHealthChecks()
                .AddDaprHealthCheck();

builder.Services.AddControllers()
                .AddDapr()
                .AddOData(opt => opt.Select().Filter().Expand().OrderBy().Count().SetMaxTop(null));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(p => p.AddPolicy("R2QCors", builder =>
{
    if (environment == "dev" || environment == "qc")
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }
    else
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }
}));

builder.Services.AddOpenTracing();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddCommonServices(builder.Configuration);
builder.Services.AddDaprClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCloudEvents();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
    endpoints.MapSubscribeHandler();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<IApplicationDbContext>();
    await dbContext.RunMigrations();

    /*var ormService = services.GetRequiredService<IOrmService>();
    ormService.InitializeOrmService();*/
}

Log.Information("Application started.");

app.Run();
