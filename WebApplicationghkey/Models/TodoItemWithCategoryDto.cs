using WebApplicationghkey.Models;

namespace WebApplicationghkey.Models
{
    public class TodoItemWithCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }


        public CategoryDto Category { get; set; }
    }
}
