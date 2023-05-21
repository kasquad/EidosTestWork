using Minio;

namespace EidosTestWork.Application.Abstractions.Storage;

// Нарушение зависимостей уровней архитектуры (сделано так для простоты).
public interface IS3Storage : 
    IBucketOperations,
    IObjectOperations,
    IMinioClient,
    IDisposable
{
}