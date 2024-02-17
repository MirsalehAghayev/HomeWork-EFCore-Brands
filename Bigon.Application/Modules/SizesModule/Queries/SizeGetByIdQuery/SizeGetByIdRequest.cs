using MediatR;

namespace Bigon.Application.Modules.SizesModule.Queries.SizeGetByIdQuery
{
    public class SizeGetByIdRequest : IRequest<SizeRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
