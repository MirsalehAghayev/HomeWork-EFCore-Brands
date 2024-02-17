using Bigon.Application.Modules.SpecificationsModule.Queries;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Queries.BrandsGetAllQuery
{
    public class BrandGetAllRequest : IRequest<IEnumerable<BrandRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
