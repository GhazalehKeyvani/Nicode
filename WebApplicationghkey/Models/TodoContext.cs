using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WebApplicationghkey.Controllers;
using WebApplicationghkey.Models;

namespace WebApplicationghkey
{
    public class TodoContext : DbContext
    {


        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TodoItem> TodoItems { get; set; }
        public virtual DbSet<Category> CategoryItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQL;Database=TodoItemsDB;Trusted_Connection=True;");
            }
        }
    } 
}
