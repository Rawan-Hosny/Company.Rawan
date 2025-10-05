using Company.Rawan.BLL.Interfaces;
using Company.Rawan.DAL.Data.Contexts;
using Company.Rawan.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Rawan.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;
        public GenericRepository(CompanyDbContext context)
        {
           _context = context;
        }
        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }
        public T? Get(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public int Add(T employee)
        {
            _context.Set<T>().Add(employee);
            return _context.SaveChanges();

        }

       

        public int Update(T employee)
        {
            _context.Set<T>().Update(employee);
            return _context.SaveChanges();

        }
        public int Delete(T employee)
        {
            _context.Set<T>().Remove(employee);
            return _context.SaveChanges();

        }



    }
}
