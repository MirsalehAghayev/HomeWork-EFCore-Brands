using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    public class CategoryGetByIdRequest : IRequest<CategoryGetByIdDto>
    {
        public int Id { get; set; }
    }
}
