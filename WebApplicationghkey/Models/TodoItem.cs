using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationghkey.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        [MaxLength(22)]
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsComplete { get; set; }

        public Category Category { get; set; }
    }
}
