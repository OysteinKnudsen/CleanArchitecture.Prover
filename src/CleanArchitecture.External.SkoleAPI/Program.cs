using CleanArchitecture.External.SkoleAPI.Data.Services;

/*
 * ################################################################################
 * # Dette er en ekstern tjeneste som du ikke skal bry deg om implementasjonen av.#
 * ################################################################################
 */


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.DocumentTitle = "Skole API");
}

app.UseHttpsRedirection();

app.MapGet("/klasser", () => new KlasseService().GetKlasser())
    .WithName("GetKlasser")
    .WithOpenApi();
app.MapGet("/elever", () => new ElevService().GetElever())
    .WithName("GetElever")
    .WithOpenApi();
app.MapGet("/lærere", () => new LærerService().GetLærere())
    .WithName("GetLærere")
    .WithOpenApi();

app.Run();