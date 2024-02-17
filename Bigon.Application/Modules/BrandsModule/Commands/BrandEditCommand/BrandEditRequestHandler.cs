using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Commands.BrandEditCommand
{
    class BrandEditRequestHandler : IRequestHandler<BrandEditRequest, Brand>
    {
        private readonly IBrandRepository brandRepository;

        public BrandEditRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public async Task<Brand> Handle(BrandEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await brandRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            entity.Name = request.Name;

            brandRepository.Edit(entity);
            await brandRepository.SaveAsync(cancellationToken);

            return entity;
        }
    }
}
