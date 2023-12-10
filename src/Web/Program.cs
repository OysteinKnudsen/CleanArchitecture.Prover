using CleanArchitecture.Prover.Application;
using CleanArchitecture.Prover.Infrastructure;
using CleanArchitecture.Prover.Web.Endpoints;
using CleanArchitecture.Prover.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddTransient<GlobalExceptionHandlerMiddleware>()
    .AddSwaggerGen()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);


var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.DocumentTitle = "Prøver API");
}

//add endpoints
app
    .AddPrøverEndpoints()
    .AddPrøvegrupperEndpoints()
    .AddSkoleEndpoints();

app.Run();

public partial class Program{} //required to use WebApplicationFactory in Web.IntegrationTests