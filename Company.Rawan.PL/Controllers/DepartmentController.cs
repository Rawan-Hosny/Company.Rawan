using Company.Rawan.BLL.Interfaces;
using Company.Rawan.BLL.Repositories;
using Company.Rawan.DAL.Models;
using Company.Rawan.PL.DTOS;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt

                };
               var Count= _departmentRepository.Add(department);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }
    }
}
