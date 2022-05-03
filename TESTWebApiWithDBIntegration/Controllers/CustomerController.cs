using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TESTDBAccessLib;
using TESTDBAccessLib.Models;
using TESTDBAccessLib.Repository;

namespace TESTWebApiWithDBIntegration.Controllers
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        //TODO: Respones
        public IRepository<CustomerModel> contextCustomers { get; private set; }

        // GET: CustomerController
        public CustomerController(IRepository<CustomerModel> _contextCustomers)
        {
            contextCustomers = _contextCustomers;
        }

        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return contextCustomers.All;
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerModel> Get(int id)
        {
            return contextCustomers.FindById(id);
        }

        [HttpPost]
        public void Post([FromBody] CustomerModel customerModel2)
        {
            contextCustomers.Add(customerModel2);
            //TODO: Respones
        }

        [HttpPut]
        public void Put([FromQuery] CustomerModel value)
        {
            contextCustomers.Update(value);
            //TODO: Respones
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             var toDelete = contextCustomers.FindById(id);
             contextCustomers.Delete(toDelete);
            //TODO: Respones
        }
    }
}
