using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add get endpoint for prøver
app.MapGet("api/prøver", (IGetPrøver getPrøver) => Results.Ok(getPrøver.GetAllPrøver()));

app.UseHttpsRedirection();
app.Run();