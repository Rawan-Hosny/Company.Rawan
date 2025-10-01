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
    public class DepartmentRepository : IDepartmentRepository
    {
        private CompanyDbContext _context;

        //Ask CLR to Create Object From This Class
        public DepartmentRepository(CompanyDbContext context )
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            
            return _context.Departments.ToList();
        }

        public Department? Get(int id)
        {
         
            return _context.Departments.Find(id);
        }

        public int Add(Department department)
        {
           
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }

        public int Update(Department department)
        {
           
           _context.Departments.Update(department);
            return _context.SaveChanges();
        }
        public int Delete(Department department)
        {
            
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }
     
    }
}
