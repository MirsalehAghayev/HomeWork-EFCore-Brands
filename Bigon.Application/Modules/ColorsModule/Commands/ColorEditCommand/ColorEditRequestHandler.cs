using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorEditCommand
{
    class ColorEditRequestHandler : IRequestHandler<ColorEditRequest, Color>
    {
        private readonly IColorRepository ColorRepository;

        public ColorEditRequestHandler(IColorRepository ColorRepository)
        {
            this.ColorRepository = ColorRepository;
        }
        public async Task<Color> Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await ColorRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            entity.Name = request.Name;
            entity.HexCode = request.HexCode;

            ColorRepository.Edit(entity);
            await ColorRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
