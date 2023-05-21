using EidosTestWork.Application.Upload.Queries.GetFileDownloadLink;
using EidosTestWork.Application.Upload.Queries.GetFilesList;
using EidosTestWork.Application.Upload.Queries.GetFileUploadLink;
using EidosTestWork.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EidosTestWork.OrderApi.Controllers;

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
    
    [HttpGet]
    [Route("downloadlink")]
    public async Task<ActionResult<string>> GetDownloadLink(
        string fileName,
        CancellationToken cancellationToken
    )
    {
        var query = new GetFileDownloadLinkQuery(fileName, 600);
        var result =await Sender.Send(query, cancellationToken);
        
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Errors);
    }
}
