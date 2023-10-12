

using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using Jaeger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.Identity.Web;
using OpenTracing.Util;
using OpenTracing;
using R2Q.Api.Middleware;
using Serilog;
using Serilog.Formatting.Compact;
using Google.Api;
using Microsoft.AspNetCore.Mvc;

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
builder.Services.AddControllers()
       .AddOData(opt => opt.Select().Filter().Expand().OrderBy().Count().SetMaxTop(null));

builder.Services.AddDaprClient();
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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
// Set up the Jaeger Tracer

builder.Services.AddSingleton<ITracer>(serviceProvider =>
{
    string serviceName = "your-service-name"; // Replace with your service name
    string jaegerAgentHost = "localhost"; // Replace with your Jaeger agent host
    int jaegerAgentPort = 6831; // Replace with your Jaeger agent port

    var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

    ISampler sampler = new ConstSampler(sample: true); // Adjust sampling as needed

    var tracer = new Tracer.Builder(serviceName)
        .WithLoggerFactory(loggerFactory)
        .WithSampler(sampler)
        .WithReporter(new RemoteReporter.Builder()
            .WithSender(new UdpSender(jaegerAgentHost, jaegerAgentPort, 0))
            .Build())
        .Build();

    GlobalTracer.Register(tracer);

    return tracer;
});
builder.Services.AddOpenTracing();
// Adds the Jaeger Tracer.
builder.Services.AddSingleton<ITracer>(sp =>
{
    var serviceName = sp.GetRequiredService<IWebHostEnvironment>().ApplicationName;
    var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    var reporter = new RemoteReporter.Builder().WithLoggerFactory(loggerFactory).WithSender(new UdpSender())
        .Build();
    var tracer = new Tracer.Builder(serviceName)
        // The constant sampler reports every span.
        .WithSampler(new ConstSampler(true))
        // LoggingReporter prints every reported span to the logging framework.
        .WithReporter(reporter)
        .Build();
    return tracer;
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
// Add the custom exception middleware
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
