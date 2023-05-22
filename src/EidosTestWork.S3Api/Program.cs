using EidosTestWork.Application.Abstractions.Storage;
using EidosTestWork.Application.Extensions;
using EidosTestWork.OrderApi.Infrastructure.Extensions;
using EidosTestWork.Persistence.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence();

builder.Services.AddApplication();
builder.AddHttp();
// Add services to the container.
builder.AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();