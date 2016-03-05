using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIDemo2.Models;

namespace WebAPIDemo2.Controllers
{
    [System.Web.Mvc.Route("api/[controller]")]
    public class TodoController : ApiController
    {

        public ITodoRepository TodoItems { get; set; }
    }
}