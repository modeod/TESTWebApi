using System;
using System.Collections.Generic;
using System.Linq;
using TESTDBAccessLib.Models;

namespace TESTDBAccessLib.Repository
{
    public class CustomerRepository : IRepository<CustomerModel>
    {
        private readonly WebApiCoreContext context;
        public CustomerRepository(WebApiCoreContext _context)
        {
            context = _context;
        }

        public IEnumerable<CustomerModel> All => context.Customers.ToList();

        public void Add(CustomerModel entity)
        {
            context.Customers.Add(entity);
            context.SaveChanges();
        }

        public void Delete(CustomerModel entity)
        {
            context.Customers.Remove(entity);
            context.SaveChanges();
        }

        public CustomerModel FindById(int id)
        {
            return context.Customers.FirstOrDefault(e => e.Id == id);
        }

        public CustomerModel FindById(string id)
        {
            return context.Customers.FirstOrDefault(e => e.Id == int.Parse(id));
        }

        public void Update(CustomerModel entity)
        {
            context.Customers.Update(entity);
            context.SaveChanges();
        }
    }
}
