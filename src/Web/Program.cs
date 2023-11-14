using CleanArchitecture.Prover.Application;
using CleanArchitecture.Prover.Infrastructure;
using CleanArchitecture.Prover.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);

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
    app.UseSwaggerUI(c => c.DocumentTitle = "Prøver API");
}

//add endpoints
app
    .AddPrøverEndpoints()
    .AddPrøveGrupperEndpoints()
    .AddSkoleEndpoints();

app.UseHttpsRedirection();
app.Run();