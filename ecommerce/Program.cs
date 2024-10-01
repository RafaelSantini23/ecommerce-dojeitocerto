using ecommerce.StartupInfra;
var builder = WebApplication.CreateBuilder(args);

var settings = ServicesExtensions.GetSettings(builder.Services);

// Add services to the container.

builder.Services
    .Configure<Settings>(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .ConfigureServices()
    .AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
