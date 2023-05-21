using EidosTestWork.Application.Abstractions.Messaging;

namespace EidosTestWork.Application.Upload.Queries.GetFileUploadLink;

public record GetFileUploadLinkQuery(string FileName,int Expiry) : IAppRequest<string>;