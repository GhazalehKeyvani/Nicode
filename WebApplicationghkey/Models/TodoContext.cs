using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WebApplicationghkey.Controllers;

namespace WebApplicationghkey
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TodoItem> TodoItems { get; set; }

    }
    
}
