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

            var departments = _departmentRepository.GetAll();

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
                var Count = _departmentRepository.Add(department);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int? id,string ViewName="Details")
        {
            if (id is null) return BadRequest("Invalid Id");
            var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound(new { StatusCode = 400, Message = "$Department With id :{id} is not found" });
            return View(ViewName,department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //if (id is null) return BadRequest("Invalid Id");
            //var department = _departmentRepository.Get(id.Value);
            //if (department is null) return NotFound(new { StatusCode = 400, Message = "$Department With id :{id} is not found" });
            return Details(id,"Edit");

        }

        [HttpPost]
        public IActionResult Edit(Department model)
        {
            if (ModelState.IsValid)
            {
                var department = _departmentRepository.Get(model.Id);
                if (department is null) return NotFound(new { StatusCode = 400, Message = "$Department With id :{model.Id} is not found" });
                department.Code = model.Code;
                department.Name = model.Name;
                department.CreateAt = model.CreateAt;
                var Count = _departmentRepository.Update(department);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //if (id is null) return BadRequest("Invalid Id");
            //var department = _departmentRepository.Get(id.Value);
            //if (department is null) return NotFound(new { StatusCode = 400, Message = "$Department With id :{id} is not found" });
            return Details(id,"Delete");
        }
        [HttpPost]
        public IActionResult Delete(Department model)
        {
            var department = _departmentRepository.Get(model.Id);
            if (department is null) return NotFound(new { StatusCode = 400, Message = "$Department With id :{model.Id} is not found" });
            var Count = _departmentRepository.Delete(department);
            if (Count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
