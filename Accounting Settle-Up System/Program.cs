using Accounting_Settle_Up_System.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "openapi/{documentName}.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "Accounting API v1");
        c.RoutePrefix = "swagger";
    });

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Accounting API")
               .WithTheme(ScalarTheme.Mars);
    });

    // Dynamic URL Logging
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        var server = app.Services.GetRequiredService<Microsoft.AspNetCore.Hosting.Server.IServer>();
        var addresses = server.Features.Get<Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>()?.Addresses;
        if (addresses != null)
        {
            Console.WriteLine("-------------------------------------------------");
            foreach (var address in addresses)
            {
                Console.WriteLine($"Swagger UI: {address}/swagger");
                Console.WriteLine($"Scalar API Reference: {address}/scalar/v1");
            }
            Console.WriteLine("-------------------------------------------------");
        }
    });
}


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();