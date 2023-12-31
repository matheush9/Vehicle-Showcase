using Microsoft.Extensions.FileProviders;
using VehicleShowcase.Application.Services.Extensions;
using VehicleShowcase.Infrastructure.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDataServices(builder.Configuration);
builder.Services.RegisterApplicationServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MigrateDatabase();
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images")),
    RequestPath = "/images"
});

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
