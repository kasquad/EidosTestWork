using System.Reflection;
using EidosTestWork.Application.Abstractions.Storage;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace EidosTestWork.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {

        services.AddScoped(m => new MinioClient()
                .WithEndpoint(Environment.GetEnvironmentVariable("MINIO_ENDPOINT"))
                .WithCredentials(
                    Environment.GetEnvironmentVariable("MINIO_ROOT_USER"),
                    Environment.GetEnvironmentVariable("MINIO_ROOT_USER_PASSWORD"))
                .WithSSL(false)
                .Build()
        );
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}