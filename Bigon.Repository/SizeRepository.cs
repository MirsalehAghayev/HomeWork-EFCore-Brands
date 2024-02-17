using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class SizeRepository : AsyncRepository<Size>, ISizeRepository
    {
        public SizeRepository(DbContext db) : base(db)
        {
        }
    }
}
