using MediatR;

namespace Bigon.Application.Modules.SizesModule.Queries.SizesGetAllQuery
{
    public class SizeGetAllRequest : IRequest<IEnumerable<SizeRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
