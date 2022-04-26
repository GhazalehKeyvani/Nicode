﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationghkey.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public Category CatId { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public Category Category { get; set; }
    }
}
