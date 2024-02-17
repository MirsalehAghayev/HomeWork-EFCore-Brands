using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
    public class ColorGetByIdRequest : IRequest<ColorRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
