using BlazorTodoList.Data.Models;
using System.Collections.Generic;

namespace BlazorTodoList.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems;
        }

        public void Add(string title)
        {
            var newItem = new TodoItem
            {
                Title = title,
                IsDone = false
            };

            _context.TodoItems.Add(newItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletedItem = _context.TodoItems.Find(id);
            if (deletedItem != null)
            {
                _context.TodoItems.Remove(deletedItem);
                _context.SaveChanges();
            }
        }

        public void Update(TodoItem item)
        {
            var updateItem = _context.TodoItems.Attach(item);
            updateItem.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
