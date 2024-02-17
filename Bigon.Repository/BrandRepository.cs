using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class BrandRepository : AsyncRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext db) : base(db)
        {
        }
    }
}
