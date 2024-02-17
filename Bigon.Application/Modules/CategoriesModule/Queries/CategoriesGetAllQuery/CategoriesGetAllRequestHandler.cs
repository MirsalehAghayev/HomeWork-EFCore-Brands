using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetAllQuery
{
    class CategoriesGetAllRequestHandler : IRequestHandler<CategoriesGetAllRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesGetAllRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(CategoriesGetAllRequest request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetAll(m => m.DeletedAt == null).ToListAsync(cancellationToken);
        }
    }
}
