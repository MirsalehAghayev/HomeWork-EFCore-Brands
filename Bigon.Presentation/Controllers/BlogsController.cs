using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IMediator mediator;

        public BlogsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("blogs/{slug}")]
        public IActionResult Details(string slug)
        {
            return Content(slug);
        }

        //public async Task<IActionResult> Details(BlogPostgetBySlugRequest request)
        //{
        //    var response = await mediator.Send(request);
        //    return View(response);
        //}

        public IActionResult AddComment()
        {
            return Json(new { });
        }
    }
}
