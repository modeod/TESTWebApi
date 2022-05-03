using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTDBAccessLib.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {   
        IEnumerable<TEntity> All { get; }
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity FindById(int id);
        TEntity FindById(string id);
    }
}
