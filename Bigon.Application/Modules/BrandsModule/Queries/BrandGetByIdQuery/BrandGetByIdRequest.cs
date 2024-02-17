using Bigon.Application.Modules.SpecificationsModule.Queries;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    public class BrandGetByIdRequest : IRequest<BrandRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
