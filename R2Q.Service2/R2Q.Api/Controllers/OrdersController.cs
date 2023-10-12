using Microsoft.AspNetCore.Mvc;

namespace R2Q.Service1.Api.Controllers
{
    public class OrdersController : Controller
    {
       

        // GET: api/orders  
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // query data from SQLite  
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/orders/1  
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            throw new System.Exception("Error Test");
            return "value";
        }
    }
}
