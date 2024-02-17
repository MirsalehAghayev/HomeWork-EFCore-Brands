namespace Bigon.Domain.Models.Dtos
{
    public class CategoryHierarcialDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }

        public IEnumerable<CategoryHierarcialDto> Children { get; set; }
    }
}
