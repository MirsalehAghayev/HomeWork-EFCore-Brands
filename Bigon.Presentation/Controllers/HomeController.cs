using Bigon.Application.Modules.ContactPostsModule.Commands.ContactPostApplyCommand;
using Bigon.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bigon.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactPostApplyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                ModelState.AddModelError("FullName", "Ad doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                ModelState.AddModelError("Email", "Email doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Subject))
            {
                ModelState.AddModelError("Subject", "Subject doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Message))
            {
                ModelState.AddModelError("Message", "Message doldurulmayib");
            }

            if (ModelState.IsValid)
            {
                await mediator.Send(request);
                return Json(new
                {
                    error = false,
                    message = "",
                    errors = new Dictionary<string, IEnumerable<string>>()
                });
            }

            //List< KeyValuePair<string,ModelStateEntry> > 

            var errors = ModelState.Select(m => new
            {
                Property = m.Key,
                Messages = m.Value.Errors.Select(m => m.ErrorMessage)
            })
                .ToDictionary(m => m.Property, v => v.Messages);

            return BadRequest(new
            {
                error = true,
                message = "Xəta var",
                errors = errors
            });
        }
    }
}
