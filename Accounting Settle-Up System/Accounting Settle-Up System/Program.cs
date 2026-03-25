using Accounting_Settle_Up_System.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference();

    var swaggerUrl = "https://localhost:5001/swagger";
    var scalarUrl = "https://localhost:5001/scalar";
    Console.WriteLine("-------------------------------------------------");
    Console.WriteLine($"Swagger UI: {swaggerUrl}");
    Console.WriteLine($"Scalar API Reference: {scalarUrl}");
    Console.WriteLine("-------------------------------------------------");
}
app.UseSwagger(c =>
{
    c.RouteTemplate = "swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Accounting API v1");
    c.RoutePrefix = "swagger"; 
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();