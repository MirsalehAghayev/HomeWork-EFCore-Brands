using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationsGetAllQuery
{
    public class SpecificationGetAllRequest : IRequest<IEnumerable<SpecificationRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
