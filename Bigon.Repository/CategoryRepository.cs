using Bigon.Application.Repositories;
using Bigon.Domain.Models.Dtos;
using Bigon.Domain.Models.Entities;
using Bigon.Domain.Models.Stables;
using Bigon.Infrastructure.Concrates;
using Bigon.Infrastructure.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class CategoryRepository : AsyncRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext db) : base(db)
        {
        }

        //public async Task<IEnumerable<RelatedCategoryIds>> GetRelatedIds(int id)
        //{
        //    var idParameter = new SqlParameter("@id",id);
        //    return await db.Database.SqlQueryRaw<RelatedCategoryIds>($"dbo.spGetRelatedIds @id", idParameter)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<RelatedCategoryIds>> GetRelatedIds(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            return await db.QueryAsync<RelatedCategoryIds>("dbo.spGetRelatedIds", parameters);
        }

        public async Task<IEnumerable<Category>> GetSafeCategories(int id,CategoryType type)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@type", (int)type);

            return await db.QueryAsync<Category>("[dbo].[spGetAllSafeCategories]", parameters);
        }
    }
}
