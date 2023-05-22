using System.Threading;
using System.Threading.Tasks;
using EidosTestWork.Application.Abstractions.Messaging;
using EidosTestWork.Application.Abstractions.Storage;
using EidosTestWork.Application.Helpers;
using Minio;

namespace EidosTestWork.Application.Upload.Queries.GetFileDownloadLink;

public class GetFileDownloadLinkQueryHandler : IAppRequestHandler<GetFileDownloadLinkQuery,string>
{
    private readonly MinioClient _minio;
    

    public GetFileDownloadLinkQueryHandler(MinioClient minio)
    {
        _minio = minio;
    }


    public async Task<Result<string>> Handle(
        GetFileDownloadLinkQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            var preArgs = new PresignedGetObjectArgs()
                .WithBucket(Constants.DefaultBucketName)
                .WithObject(query.FileName)
                .WithExpiry(query.Expiry);

            var link = await _minio.PresignedGetObjectAsync(preArgs);

            return Result<string>.Success(link);

        }
        catch (S3StorageException ex)
        {
            // Logging..
            return Result<string>.Failure("Storage exception");
        }
    }
}