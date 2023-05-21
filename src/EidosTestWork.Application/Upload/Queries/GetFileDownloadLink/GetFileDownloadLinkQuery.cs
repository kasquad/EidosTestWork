using EidosTestWork.Application.Abstractions.Messaging;

namespace EidosTestWork.Application.Upload.Queries.GetFileDownloadLink;

public record GetFileDownloadLinkQuery(string FileName,int Expiry) : IAppRequest<string>;