using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.ColorsModule.Queries.ColorsGetAllQuery
{
    class ColorGetAllRequestHandler : IRequestHandler<ColorGetAllRequest, IEnumerable<ColorRequestDto>>
    {
        private readonly IColorRepository ColorRepository;

        public ColorGetAllRequestHandler(IColorRepository ColorRepository)
        {
            this.ColorRepository = ColorRepository;
        }

        public async Task<IEnumerable<ColorRequestDto>> Handle(ColorGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = ColorRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedBy == null);
            }

            var response = await query.Select(m => new ColorRequestDto
            {
                Id = m.Id,
                Name = m.Name,
                HexCode = m.HexCode,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
