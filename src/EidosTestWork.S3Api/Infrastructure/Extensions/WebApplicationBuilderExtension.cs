using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using EidosTestWork.OrderApi.Infrastructure.ExceptionFilters;
using Microsoft.OpenApi.Models;
using EidosTestWork.OrderApi.Infrastructure.StartupFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EidosTestWork.OrderApi.Infrastructure.Extensions;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddHttp(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>())
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        return builder;
    }

    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo() { Title = "EidosTestWork.S3Api" });
            options.CustomSchemaIds(s => s.FullName);

            // Add ability show comments above class in swagger
            var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);

            options.IncludeXmlComments(xmlFilePath);
        });

        // TODO: Find why this broke endpoints
        // builder.Services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
        return builder;
    }
}