using Company.Rawan.BLL.Interfaces;
using Company.Rawan.BLL.Repositories;
using Company.Rawan.DAL.Models;
using Company.Rawan.PL.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

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
   public IActionResult Edit(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                return NotFound();
            }
            var model = new CreateDepartmentDto()
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = department.CreateAt
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id is null)return BadRequest("Invalid Id");
            var department = _departmentRepository.Get(id.Value);
            if(department is null) return NotFound(new {StatusCode=400,Message="$Department With id :{id} is not found"});
            return View(department);
        }

    }
}
