using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    class CategoryGetByIdRequestHandler : IRequestHandler<CategoryGetByIdRequest, CategoryGetByIdDto>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryGetByIdRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryGetByIdDto> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {
            //var entity = await categoryRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            var dto = await (from c in categoryRepository.GetAll(m => m.DeletedAt == null)
                       join p in categoryRepository.GetAll() on c.ParentId equals p.Id into leftJoin
                       from l in leftJoin.DefaultIfEmpty()
                       where c.Id == request.Id
                       select new CategoryGetByIdDto
                       {
                           Id = c.Id,
                           Name = c.Name,
                           ParentId = c.ParentId,
                           ParentName = l.Name,
                           Type = c.Type,
                       }).FirstOrDefaultAsync(cancellationToken);

            return dto;

            //var dto = new CategoryGetByIdDto
            //{
            //    Id = entity.Id,
            //    Name = entity.Name,
            //    ParentId = entity.ParentId,
            //    Type = entity.Type,
            //};

                      //if (entity.ParentId is not null)
                      //{
                      //    var parent = await categoryRepository.GetAsync(m => m.Id == entity.ParentId && m.DeletedAt == null, cancellationToken);

                      //    dto.ParentName = parent.Name;
                      //}
        }
    }
}
