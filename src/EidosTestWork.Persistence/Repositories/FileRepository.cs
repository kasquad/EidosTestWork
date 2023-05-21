using EidosTestWork.Application.Abstractions.Repositories;
using EidosTestWork.Application.Helpers;
using EidosTestWork.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace EidosTestWork.Persistence.Repositories;

public sealed class FileRepository : IFileRepository
{
    private readonly AppDbContext _context;

    public FileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<string>> GetFileNamesAsync(
        CancellationToken cancellationToken = default
        )
    {
        return await _context.FilesDescription
            .Select(f => f.Path)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<FileDescription>> GetFilesDescriptionsAsync(
        CancellationToken cancellationToken = default
        )
    {
        return await _context.FilesDescription
            .ToListAsync(cancellationToken: cancellationToken);
    }
}