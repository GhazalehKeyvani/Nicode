using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationghkey.Models
{
    public class Category
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(22)]
        public string Name { get; set; }
        [Required]
        public int Order { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; }
    }
}
