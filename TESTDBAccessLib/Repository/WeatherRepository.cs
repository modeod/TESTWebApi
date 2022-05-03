using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTDBAccessLib.Models;

namespace TESTDBAccessLib.Repository
{
    public class WeatherRepository : IRepository<CurrentWeatherModel>
    {
        private readonly WebApiCoreContext context;
        public WeatherRepository(WebApiCoreContext _context)
        {
            context = _context;
        }

        public IEnumerable<CurrentWeatherModel> All => context.Weathers.ToList();

        public void Add(CurrentWeatherModel entity)
        {
            context.Weathers.Add(entity);
            context.SaveChanges();
        }

        public void Delete(CurrentWeatherModel entity)
        {
            context.Weathers.Remove(entity);
            context.SaveChanges();
        }

        public CurrentWeatherModel FindById(int id)
        {
            return context.Weathers.FirstOrDefault(e => e.Id == id);
        }

        public CurrentWeatherModel FindById(string id)
        {
            return context.Weathers.FirstOrDefault(e => e.Id == int.Parse(id));
        }

        public void Update(CurrentWeatherModel entity)
        {
            context.Weathers.Update(entity);
            context.SaveChanges();
        }
    }
}
