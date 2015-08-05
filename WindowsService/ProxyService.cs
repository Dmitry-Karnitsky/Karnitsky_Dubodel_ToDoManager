using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public class ToDoProxyService : IToDoProxyService
    {
        public ToDoItem CreateToDoItem(ToDoItem item)
        {
            var client = new ToDoManager.ToDoManagerClient();
            var toDoItem = new ToDoManager.ToDoItem()
            {
                Name = item.Name,
                IsCompleted = item.IsCompleted,
                ToDoId = item.ToDoId,
                UserId = item.UserId
            };

            client.CreateToDoItem(toDoItem);
            return item;

        }

        public int CreateUser(string name)
        {
            var client = new ToDoManager.ToDoManagerClient();
            var id = client.CreateUser(name);
            return id;
        }

        public void DeleteToDoItem(int todoItemId)
        {
            var client = new ToDoManager.ToDoManagerClient();
            client.DeleteToDoItem(todoItemId);
        }

        public List<ToDoItem> GetTodoList(int userId)
        {
            var client = new ToDoManager.ToDoManagerClient();
            var userList = client.GetTodoList(userId);
            return userList.Select(x => new ToDoItem()
            {
                IsCompleted = x.IsCompleted,
                Name = x.Name,
                ToDoId = x.ToDoId,
                UserId = x.UserId
            }).ToList();
        }

        public void UpdateToDoItem(ToDoItem item)
        {
            var client = new ToDoManager.ToDoManagerClient();
            var toDoItem = new ToDoManager.ToDoItem()
            {
                Name = item.Name,
                IsCompleted = item.IsCompleted,
                ToDoId = item.ToDoId,
                UserId = item.UserId
            };
            client.UpdateToDoItem(toDoItem);
        }
    }
}
