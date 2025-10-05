using Company.Rawan.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Rawan.BLL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? Get(int id);
        int Add(Employee employee);
        int Update(Employee employee);
        int Delete(Employee employee);
    }
}
