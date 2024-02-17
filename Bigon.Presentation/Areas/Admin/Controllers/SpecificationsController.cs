using Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationAddCommand;
using Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationEditCommand;
using Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationRemoveCommand;
using Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationGetByIdQuery;
using Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationsGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecificationsController : Controller
    {
        private readonly IMediator mediator;

        public SpecificationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(SpecificationGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details([FromRoute] SpecificationGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpecificationAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit([FromRoute]SpecificationGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SpecificationEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> Remove(SpecificationRemoveRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
