using Microsoft.AspNetCore.Hosting;
using NN.Digi.Store.Domain;
using NN.Digi.Store.Infrastructure;
using NN.Digi.Store.Infrastructure.Mongo;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var applicationSetting = new ApplicationSetting();
builder.Configuration.GetSection("ApplicationSetting").Bind(applicationSetting);
builder.Services.AddSingleton(applicationSetting);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddInfrastructure(applicationSetting);

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
