using Bigon.Infrastructure.Abstracts;

namespace Bigon.Application.Services.Identity
{
    public class FakeIdentityService : IIdentityService
    {
        public int? GetPrincipialId()
        {
            return null;
        }
    }
}
