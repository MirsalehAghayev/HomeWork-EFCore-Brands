using Bigon.Domain.Models.Stables;
using System.ComponentModel;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    public class CategoryGetByIdDto
    {
        public int Id { get; set; }
        [DisplayName("Parent")]
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
