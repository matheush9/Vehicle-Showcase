using VehicleShowcase.Application.Services.Extensions;
using VehicleShowcase.Infrastructure.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDataServices(builder.Configuration);
builder.Services.RegisterApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MigrateDatabase();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
