using Microsoft.AspNetCore.Mvc;
using TESTDBAccessLib.Models;
using TESTDBAccessLib.Repository;

namespace TESTWebApiWithDBIntegration.Controllers
{
    [ApiController]
    [Route("api/Weather")]
    public class WeatherController : Controller
    {
        public IRepository<CurrentWeatherModel> contextCustomers { get; private set; }

        // GET: CustomerController
        public WeatherController(IRepository<CurrentWeatherModel> _contextCustomers)
        {
            contextCustomers = _contextCustomers;
        }

        [HttpGet]
        public IEnumerable<CurrentWeatherModel> Get()
        {
            return contextCustomers.All;
        }

        [HttpGet("{id}")]
        public ActionResult<CurrentWeatherModel> Get(int id)
        {
            return contextCustomers.FindById(id);
            //TODO: Respones
        }

        [HttpPost]
        public void Post([FromBody] CurrentWeatherModel customerModel2)
        {
            contextCustomers.Add(customerModel2);
            //TODO: Respones

        }

        [HttpPut]
        public void Put([FromQuery] CurrentWeatherModel value)
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
