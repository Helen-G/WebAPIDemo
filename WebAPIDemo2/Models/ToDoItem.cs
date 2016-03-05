using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo2.Models
{
    public class TodoItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}