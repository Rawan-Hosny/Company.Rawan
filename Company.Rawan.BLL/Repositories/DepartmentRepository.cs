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
    public class DepartmentRepository :GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CompanyDbContext context) : base(context)
        {
        }

    }
}
