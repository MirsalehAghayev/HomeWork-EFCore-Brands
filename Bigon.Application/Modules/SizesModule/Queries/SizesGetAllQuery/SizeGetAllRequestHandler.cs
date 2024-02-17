using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.SizesModule.Queries.SizesGetAllQuery
{
    class SizeGetAllRequestHandler : IRequestHandler<SizeGetAllRequest, IEnumerable<SizeRequestDto>>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeGetAllRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public async Task<IEnumerable<SizeRequestDto>> Handle(SizeGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = sizeRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var response = await query.Select(m => new SizeRequestDto
            {
                Id = m.Id,
                Name = m.Name,
                SmallName = m.SmallName,
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
