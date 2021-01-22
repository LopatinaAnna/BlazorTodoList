using BlazorTodoList.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorTodoList.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task Add(string title)
        {
            var newItem = new TodoItem
            {
                Title = title,
                IsDone = false
            };

            await _context.TodoItems.AddAsync(newItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var deletedItem = await _context.TodoItems.FindAsync(id);

            if (deletedItem != null)
            {
                _context.TodoItems.Remove(deletedItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAll()
        {
            var items = await GetAll();
            _context.TodoItems.RemoveRange(items);

            await _context.SaveChangesAsync();
        }

        public async Task Update(TodoItem item)
        {
            var updateItem = _context.TodoItems.Attach(item);
            updateItem.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}