using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EidosTestWork.Application.Upload.Queries.GetFileDownloadLink;
using EidosTestWork.Application.Upload.Queries.GetFilesList;
using EidosTestWork.Application.Upload.Queries.GetFileUploadLink;
using EidosTestWork.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EidosTestWork.OrderApi.Controllers;

/// <summary>
/// Заменить minio на localhost для получения корректных ссылок
/// </summary>
[ApiController]
[Route("api/files")]
public class FilesController : AppControllerBase
{
    private readonly AppDbContext _context;
    public FilesController(ISender sender, AppDbContext context) : base(sender)
    {
        _context = context;
    }
    [HttpGet]
    [Route((""))]
    public async Task<ActionResult<IEnumerable<string>>> GetFileList(
        CancellationToken cancellationToken
        )
    {
        var query = new GetFileListQuery();
        var result = await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Errors);
    }

    /// <summary>
    /// Создаёт загрузочную ссылку на S3 хранилище со сроком действия 10 минут
    /// </summary>
    /// <param name="fileName">Будущее название файла в S3</param>
    /// <returns></returns>
    [HttpGet]
    [Route("uploadlink")]
    public async Task<ActionResult<string>> GetUploadLink(
        string fileName,
        CancellationToken cancellationToken
        )
    {
        var query = new GetFileUploadLinkQuery(fileName, 600);
        var result =await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Errors);
    }
    
    /// <summary>
    /// Создаёт загрузочную ссылку с недельным сроком действия
    /// </summary>
    /// <param name="fileName">Название файла в S3 хранилище</param>
    /// <returns></returns>
    [HttpGet]
    [Route("downloadlink")]
    public async Task<ActionResult<string>> GetDownloadLink(
        string fileName,
        CancellationToken cancellationToken
    )
    {
        var query = new GetFileDownloadLinkQuery(fileName, 7*24*3600);
        var result =await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Errors);
    }
}
