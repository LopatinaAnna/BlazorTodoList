using BlazorTodoList.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorTodoList.Data.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();

        Task Add(string title);

        Task Update(TodoItem item);

        Task Delete(int id);

        Task DeleteAll();
    }
}