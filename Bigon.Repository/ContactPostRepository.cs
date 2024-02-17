using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using Bigon.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Repository
{
    class ContactPostRepository : AsyncRepository<ContactPost>, IContactPostRepository
    {
        public ContactPostRepository(DbContext db) : base(db)
        {
        }
    }
}
