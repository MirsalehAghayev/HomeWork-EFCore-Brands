using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationsGetAllQuery
{
    class SpecificationGetAllRequestHandler : IRequestHandler<SpecificationGetAllRequest, IEnumerable<SpecificationRequestDto>>
    {
        private readonly ISpecificationRepository specificationRepository;

        public SpecificationGetAllRequestHandler(ISpecificationRepository specificationRepository)
        {
            this.specificationRepository = specificationRepository;
        }

        public async Task<IEnumerable<SpecificationRequestDto>> Handle(SpecificationGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = specificationRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedBy == null);
            }

            var response = await query.Select(m => new SpecificationRequestDto
            {
                Id = m.Id,
                Name = m.Name
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
