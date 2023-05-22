using System;
using EidosTestWork.Application.Abstractions.Repositories;
using EidosTestWork.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EidosTestWork.Persistence.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultPostgresConnectionString"));
            // options.UseNpgsql("Host=localhost:5426;Database=minio-db;Username=postgres;Password=minioPassword;");
        });


        services.AddTransient<IFileRepository, FileRepository>();
        
        return services;
    }
}