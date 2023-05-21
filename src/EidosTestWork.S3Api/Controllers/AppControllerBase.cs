using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EidosTestWork.OrderApi.Controllers;

public class AppControllerBase : ControllerBase
{
    public AppControllerBase(ISender sender)
    {
        _sender = sender;
    }

    private ISender _sender { get; set; }
    
    protected ISender Sender { get => _sender; }
    
   
}