using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class SpecificationRepository : AsyncRepository<Specification>, ISpecificationRepository
    {
        public SpecificationRepository(DbContext db) : base(db) { }
    }
}
