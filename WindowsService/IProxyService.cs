using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{   
        [ServiceContract]
        public interface IToDoProxyService
        {
            [OperationContract]
            ToDoItem CreateToDoItem(ToDoItem item);

            [OperationContract]
            int CreateUser(string name);

            [OperationContract]
            void DeleteToDoItem(int todoItemId);

            [OperationContract]
            List<ToDoItem> GetTodoList(int userId);

            [OperationContract]
            void UpdateToDoItem(ToDoItem todo);

        }

        // Use a data contract as illustrated in the sample below to add composite types to service operations.
        // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ToDoProxeService.ContractType".
        [DataContract]
        public class ToDoItem
        {
            [DataMember]
            public int UserId { get; set; }

            [DataMember]
            public int ToDoId { get; set; }

            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public bool IsCompleted { get; set; }
        }
    
}
