using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    class CategoryAddRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryAddRequest>
    {
        public async Task Handle(CategoryAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Category
            {
                Name = request.Name,
                Type = request.Type
            };

            if (request.ParentId is not null)
            {
                var parent = await categoryRepository.GetAsync(m => m.Id == request.ParentId, cancellationToken);

                entity.ParentId = parent.Id;
            }

            await categoryRepository.AddAsync(entity);
            await categoryRepository.SaveAsync(cancellationToken);
        }
    }
}
