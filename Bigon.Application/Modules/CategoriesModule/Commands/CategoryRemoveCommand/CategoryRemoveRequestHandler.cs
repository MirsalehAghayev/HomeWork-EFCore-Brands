using Bigon.Application.Repositories;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryRemoveCommand
{
    class CategoryRemoveRequestHandler : IRequestHandler<CategoryRemoveRequest>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryRemoveRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task Handle(CategoryRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await categoryRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);

            categoryRepository.Remove(entity);
            await categoryRepository.SaveAsync(cancellationToken);
        }
    }
}
