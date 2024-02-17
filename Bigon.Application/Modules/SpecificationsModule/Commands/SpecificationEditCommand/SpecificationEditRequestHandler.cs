using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationEditCommand
{
    class SpecificationEditRequestHandler : IRequestHandler<SpecificationEditRequest, Specification>
    {
        private readonly ISpecificationRepository specificationRepository;

        public SpecificationEditRequestHandler(ISpecificationRepository specificationRepository)
        {
            this.specificationRepository = specificationRepository;
        }
        public async Task<Specification> Handle(SpecificationEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await specificationRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            entity.Name = request.Name;

            specificationRepository.Edit(entity);
            await specificationRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
