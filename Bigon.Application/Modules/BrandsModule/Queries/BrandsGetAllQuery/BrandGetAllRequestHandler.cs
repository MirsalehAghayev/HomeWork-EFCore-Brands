using Bigon.Application.Modules.SpecificationsModule.Queries;
using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.BrandsModule.Queries.BrandsGetAllQuery
{
    class BrandGetAllRequestHandler : IRequestHandler<BrandGetAllRequest, IEnumerable<BrandRequestDto>>
    {
        private readonly IBrandRepository brandRepository;

        public BrandGetAllRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<IEnumerable<BrandRequestDto>> Handle(BrandGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = brandRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var response = await query.Select(m => new BrandRequestDto
            {
                Id = m.Id,
                Name = m.Name
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
