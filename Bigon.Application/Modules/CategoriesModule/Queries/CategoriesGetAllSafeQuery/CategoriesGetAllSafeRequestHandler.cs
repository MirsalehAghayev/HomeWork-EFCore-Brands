using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetAllSafeQuery
{
    class CategoriesGetAllSafeRequestHandler : IRequestHandler<CategoriesGetAllSafeRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesGetAllSafeRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Task<IEnumerable<Category>> Handle(CategoriesGetAllSafeRequest request, CancellationToken cancellationToken)
        {
            return categoryRepository.GetSafeCategories(request.Id, request.Type);
        }
    }
}
