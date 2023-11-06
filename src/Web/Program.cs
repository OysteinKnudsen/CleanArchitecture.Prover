using CleanArchitecture.Prover.Application;
using CleanArchitecture.Prover.Infrastructure;
using CleanArchitecture.Prover.Web.Endpoints;
using CleanArchitecture.Prover.Web.Extensions;
using Serilog;

// Instantiate a bootstrap logger which works before the WebApplicationBuilder has completed.
Log.Logger = new LoggerConfiguration()
    .ConfigureLogging()
    .CreateBootstrapLogger();

Log.Debug("CleanArchitecture.Prover - starting...");

var builder = WebApplication.CreateBuilder(args);

// Create the final logger which has access to the HostBuilderContext and DI
builder.Host.UseSerilog((_, _, configuration) => configuration.ConfigureLogging());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add endpoints
app
    .AddRootEndpoint()
    .AddPrøverEndpoints()
    .AddPrøveGrupperEndpoints();

app.UseHttpsRedirection();

app.Logger.LogDebug("CleanArchitecture.Prover.Web - done setting up app");

app.Run();