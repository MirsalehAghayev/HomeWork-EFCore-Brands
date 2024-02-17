using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorAddCommand
{
    class ColorAddRequestHandler : IRequestHandler<ColorAddRequest, Color>
    {
        private readonly IColorRepository ColorRepository;

        public ColorAddRequestHandler(IColorRepository ColorRepository)
        {
            this.ColorRepository = ColorRepository;
        }
        public async Task<Color> Handle(ColorAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Color
            {
                Name = request.Name,
                HexCode = request.HexCode,
            };

            await ColorRepository.AddAsync(entity, cancellationToken);
            await ColorRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
