using System.Threading;
using System.Threading.Tasks;
using EidosTestWork.Application.Abstractions.Messaging;
using EidosTestWork.Application.Abstractions.Storage;
using EidosTestWork.Application.Helpers;
using Minio;

namespace EidosTestWork.Application.Upload.Queries.GetFileUploadLink;

public class GetFileUploadLinkQueryHandler : IAppRequestHandler<GetFileUploadLinkQuery,string>
{
    private readonly MinioClient _minio;
    

    public GetFileUploadLinkQueryHandler(MinioClient minio)
    {
        _minio = minio;
    }


    public async Task<Result<string>> Handle(
        GetFileUploadLinkQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            var preArgs = new PresignedPutObjectArgs()
                .WithBucket(Constants.DefaultBucketName)
                .WithObject(query.FileName)
                    .WithExpiry(query.Expiry);

            var link = await _minio.PresignedPutObjectAsync(preArgs);

            return Result<string>.Success(link);

        }
        catch (S3StorageException ex)
        {
            // Logging..
            return Result<string>.Failure("Storage exception");
        }
    }
}