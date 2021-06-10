using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace App.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected string CurrentUri => HttpContext.Request.Path.ToUriComponent();

        protected string RemoteIpAddress => HttpContext.Connection.RemoteIpAddress.ToString();

    }
}
