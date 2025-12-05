using JusTechRun.Api.Domain;
using JusTechRun.Api.Services;
using JusTechRun.Api.Tokenization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddSingleton<ICrmService, CrmService>();
builder.Services.AddSingleton<TokenizationEngine>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok", service = "JusTechRun.Api" }));

// CRM endpoints
app.MapGet("/crm/clients", (ICrmService crm) =>
{
    var clients = crm.GetClients();
    return Results.Ok(clients);
});

app.MapPost("/crm/clients", (ICrmService crm, Client client) =>
{
    crm.AddClient(client);
    return Results.Created($"/crm/clients/{client.Id}", client);
});

// Tokenization endpoints
app.MapGet("/tokenization/assets", (TokenizationEngine engine) =>
{
    var assets = engine.GetRegisteredAssets();
    return Results.Ok(assets);
});

app.MapPost("/tokenization/assets/register", (TokenizationEngine engine, TokenizedAsset asset) =>
{
    var result = engine.RegisterAsset(asset);
    return result.IsValid
        ? Results.Created($"/tokenization/assets/{asset.Id}", asset)
        : Results.BadRequest(result.Errors);
});

app.Run();

namespace JusTechRun.Api { public partial class Program { } }
