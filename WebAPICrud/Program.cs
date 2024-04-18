using System.Configuration;
using WebAPICrud.Core.BL.Interfaces;
using WebAPICrud.Core.BL.Service;
using WebAPICrud.Core.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ContextConfiguration.ConexionString = builder.Configuration.GetConnectionString("DBConexion");

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(c => c.AddPolicy(MyAllowSpecificOrigins, builder =>
{ 
   builder
  .WithOrigins("*")
  .AllowAnyMethod()
  .AllowAnyHeader();

}));

/// se hace las instancia a alas interfaces y servicios 
builder.Services.AddTransient<ICatalogos, CatalogoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
