using Company.Rawan.BLL.Interfaces;
using Company.Rawan.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Company.Rawan.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        //Ask CLR Create Object From This Class
        public DepartmentController(IDepartmentRepository departmentReositroy)
        {
            _departmentRepository = departmentReositroy;
        }
        [HttpGet]// Get : /Department/Index
        public IActionResult Index()
        {
            
          var departments= _departmentRepository.GetAll();

            return View(departments);
        }
    }
}
