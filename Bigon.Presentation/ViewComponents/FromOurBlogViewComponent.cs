using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.ViewComponents
{
    public class FromOurBlogViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FromOurBlogViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    return View();
        //}

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
