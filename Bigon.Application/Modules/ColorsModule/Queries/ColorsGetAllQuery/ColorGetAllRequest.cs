using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Queries.ColorsGetAllQuery
{
    public class ColorGetAllRequest : IRequest<IEnumerable<ColorRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
