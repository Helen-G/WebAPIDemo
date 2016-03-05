using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo2.Models
{
    //an object that encapsulates the data layer, and contains logic for retrieving data and mapping it to an entity model.
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }

}