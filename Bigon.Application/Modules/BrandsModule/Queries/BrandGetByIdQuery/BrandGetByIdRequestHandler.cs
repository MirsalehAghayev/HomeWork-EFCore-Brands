using Bigon.Application.Modules.SpecificationsModule.Queries;
using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    class BrandGetByIdRequestHandler : IRequestHandler<BrandGetByIdRequest, BrandRequestDto>
    {
        private readonly IBrandRepository brandRepository;

        public BrandGetByIdRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<BrandRequestDto> Handle(BrandGetByIdRequest request, CancellationToken cancellationToken)
        {
            Brand entity;

            if (request.OnlyAvailable)
            {
                entity = await brandRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            }
            else
            {
                entity = await brandRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            var dto = new BrandRequestDto
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            return dto;
        }
    }
}
