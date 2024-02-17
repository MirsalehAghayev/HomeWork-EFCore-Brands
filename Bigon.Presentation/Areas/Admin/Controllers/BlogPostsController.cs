using Bigon.Application.Modules.BlogPostsModule.Commands.BlogPostAddCommand;
using Bigon.Application.Modules.BlogPostsModule.Commands.BlogPostEditCommand;
using Bigon.Application.Modules.BlogPostsModule.Queries.BlogPostGetAllQuery;
using Bigon.Application.Modules.BlogPostsModule.Queries.BlogPostGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(BlogPostGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BlogPostAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute] BlogPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] BlogPostEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
