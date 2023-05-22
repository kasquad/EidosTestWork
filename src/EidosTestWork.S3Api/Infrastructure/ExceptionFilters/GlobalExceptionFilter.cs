using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EidosTestWork.OrderApi.Infrastructure.ExceptionFilters;

public class GlobalExceptionFilter : ExceptionFilterAttribute
{ 
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);
        var resultObject = new
        {
            ExceptionType = context.Exception.GetType().FullName,
            Message = context.Exception.Message,
            StatucCode = StatusCodes.Status500InternalServerError
        };
        var jsonResult = new JsonResult(resultObject);

        context.Result = jsonResult;
    }
}