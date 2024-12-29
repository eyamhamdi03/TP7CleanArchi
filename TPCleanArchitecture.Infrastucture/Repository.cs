using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCleanArchitecture.Domain;
using TPCleanArchitecture.Infrastucture;

namespace TPCleanArchitecture.Infrastructure
{ 
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _context;

        public Repository(AppDBContext context)
        {
            _context = context;
        }

        public T GetById(int id) => _context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}