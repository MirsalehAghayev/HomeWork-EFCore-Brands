using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationAddCommand
{
    class SpecificationAddRequestHandler : IRequestHandler<SpecificationAddRequest, Specification>
    {
        private readonly ISpecificationRepository specificationRepository;

        public SpecificationAddRequestHandler(ISpecificationRepository specificationRepository)
        {
            this.specificationRepository = specificationRepository;
        }
        public async Task<Specification> Handle(SpecificationAddRequest request, CancellationToken cancellationToken)
        {
            var specification = new Specification
            {
                Name = request.Name,
            };

            specification = await specificationRepository.AddAsync(specification, cancellationToken);
            await specificationRepository.SaveAsync(cancellationToken);

            return specification;
        }
    }
}
