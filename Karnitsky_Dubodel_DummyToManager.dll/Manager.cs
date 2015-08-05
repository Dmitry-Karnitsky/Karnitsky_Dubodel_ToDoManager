using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure;

namespace Karnitsky_Dubodel_DummyToManager.dll
{
    public class ToDoProxyManager : IToDoManager
    {
        public ToDoProxyManager()
        {
            //ProcessStartInfo procStartInfo = new ProcessStartInfo("ConsoleApplication1.exe");
            //procStartInfo.RedirectStandardOutput = true;
            //procStartInfo.UseShellExecute = false;
            //procStartInfo.CreateNoWindow = true;
            //Process proc = new Process();
            //proc.StartInfo = procStartInfo;
            //proc.Start();
        }


        public void CreateToDoItem(IToDoItem item)
        {
            var client = new ToDoProxyService.Service1Client();
            var toDoItem = new ToDoProxyService.ToDoItem()
            {
                Name = item.Name,
                IsCompleted = item.IsCompleted,
                ToDoId = item.ToDoId,
                UserId = item.UserId
            };

            client.CreateToDoItem(toDoItem);
        }

        public int CreateUser(string name)
        {
            var client = new ToDoProxyService.Service1Client();
            var id = client.CreateUser(name);
            return id;
        }

        public void DeleteToDoItem(int todoItemId)
        {
            var client = new ToDoProxyService.Service1Client();
            client.DeleteToDoItem(todoItemId);
        }

        public List<IToDoItem> GetTodoList(int userId)
        {
            var client = new ToDoProxyService.Service1Client();
            var userList = client.GetTodoList(userId);
            return new List<IToDoItem>();
            //return userList.Select(x => new Item()
            //{
            //    IsCompleted = x.IsCompleted,
            //    Name = x.Name,
            //    ToDoId = x.ToDoId,
            //    UserId = x.UserId
            //}).ToList();
        }

        public void UpdateToDoItem(IToDoItem item)
        {
            var client = new ToDoProxyService.Service1Client();
            var toDoItem = new ToDoProxyService.ToDoItem()
            {
                Name = item.Name,
                IsCompleted = item.IsCompleted,
                ToDoId = item.ToDoId,
                UserId = item.UserId
            };
            client.UpdateToDoItem(toDoItem);
        }
    }

    public class Item : IToDoItem
    {
        public bool IsCompleted { get; set; }

        public string Name { get; set; }

        public int ToDoId { get; set; }

        public int UserId { get; set; }
    }
}
