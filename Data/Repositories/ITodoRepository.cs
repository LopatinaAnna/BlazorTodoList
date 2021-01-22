using BlazorTodoList.Data.Models;
using System.Collections.Generic;

namespace BlazorTodoList.Data.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();

        void Add(string title);

        void Update(TodoItem item);

        void Delete(int id);

        void DeleteAll();
    }
}