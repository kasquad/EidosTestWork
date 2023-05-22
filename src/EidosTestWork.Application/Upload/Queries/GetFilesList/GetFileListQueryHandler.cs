using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EidosTestWork.Application.Abstractions.Messaging;
using EidosTestWork.Application.Abstractions.Repositories;
using EidosTestWork.Application.Helpers;

namespace EidosTestWork.Application.Upload.Queries.GetFilesList;

public sealed class GetFileListQueryHandler : IAppRequestHandler<GetFileListQuery,IEnumerable<string>>
{
    private readonly IFileRepository _fileRepository;

    public GetFileListQueryHandler(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public async Task<Result<IEnumerable<string>>> Handle(
        GetFileListQuery query,
        CancellationToken cancellationToken)
    {
        return Result<IEnumerable<string>>.Success(await _fileRepository.GetFileNamesAsync(cancellationToken));
    }
}