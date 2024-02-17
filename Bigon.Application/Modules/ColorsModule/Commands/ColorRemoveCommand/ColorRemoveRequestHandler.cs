using Bigon.Application.Repositories;
using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorRemoveCommand
{
    class ColorRemoveRequestHandler : IRequestHandler<ColorRemoveRequest>
    {
        private readonly IColorRepository ColorRepository;

        public ColorRemoveRequestHandler(IColorRepository ColorRepository)
        {
            this.ColorRepository = ColorRepository;
        }

        public async Task Handle(ColorRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await ColorRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);

            ColorRepository.Remove(entity);
            await ColorRepository.SaveAsync(cancellationToken);
        }
    }
}
