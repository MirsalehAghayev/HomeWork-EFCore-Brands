using MediatR;

namespace Bigon.Application.Modules.BlogPostsModule.Queries.BlogPostGetAllQuery
{
    public class BlogPostGetAllRequest : IRequest<IEnumerable<BlogPostGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
