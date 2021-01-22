using BlazorTodoList.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}