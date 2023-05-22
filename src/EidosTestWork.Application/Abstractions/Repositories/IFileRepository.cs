using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EidosTestWork.Application.Models;

namespace EidosTestWork.Application.Abstractions.Repositories;

public interface IFileRepository
{
    public Task<IEnumerable<string>> GetFileNamesAsync(CancellationToken cancellationToken = default);
    
    public Task<IEnumerable<FileDescription>> GetFilesDescriptionsAsync(CancellationToken cancellationToken = default);
}