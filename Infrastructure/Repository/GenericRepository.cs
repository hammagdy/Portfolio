using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> Table = null;
        public GenericRepository(DataContext context)
        {
           _context = context;
            Table = _context.Set<T>();
        }


        public void Delete(object id)
        {
            T existing = GetById(id);
            Table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return Table.ToList(); 
        }

        public T GetById(object id)
        {
            return Table.Find(id);
        }

        public void Insert(T entity)
        {
            Table.Add(entity);
        }

        public void Update(T entity)
        {
            Table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
