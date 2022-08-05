using CaveVinsMrTerence.Services;
using MrTerenceWebAPI.Services.AdresseService;
using MrTerenceWebAPI.Services.EmplacementService;
using MrTerenceWebAPI.Services.FournisseurService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBouteilleService, BouteilleService>();
builder.Services.AddScoped<IAdresseService, AdresseService>();
builder.Services.AddScoped<IEmplacementService, EmplacementService>();
builder.Services.AddScoped<IFournisseurService, FournisseurService>();

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
