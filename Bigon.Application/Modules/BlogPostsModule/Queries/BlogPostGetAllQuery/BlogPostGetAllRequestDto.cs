namespace Bigon.Application.Modules.BlogPostsModule.Queries.BlogPostGetAllQuery
{
    public class BlogPostGetAllRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
    }
}
