using System.Collections.Generic;
using EidosTestWork.Application.Abstractions.Messaging;

namespace EidosTestWork.Application.Upload.Queries.GetFilesList;

public record GetFileListQuery : IAppRequest<IEnumerable<string>>;