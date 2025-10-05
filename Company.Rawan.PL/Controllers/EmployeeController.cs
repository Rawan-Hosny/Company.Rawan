using Company.Rawan.BLL.Interfaces;
using Company.Rawan.DAL.Models;
using Company.Rawan.PL.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace Company.Rawan.PL.Controllers
{
    public class EmployeeController : Controller
    {
       
            private readonly IEmployeeRepository _employeeRepository;
            //Ask CLR Create Object From This Class
            public EmployeeController(IEmployeeRepository employeeRepositroy)
            {
            _employeeRepository = employeeRepositroy;
            }
            [HttpGet]// Get : /Employee/Index
            public IActionResult Index()
            {

                var employees = _employeeRepository.GetAll();

                return View(employees);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(CreateEmployeeDto model)
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Name = model.Name,
                        Age = model.Age,
                        Email = model.Email,
                        Address = model.Address,
                        Phone = model.Phone,
                        Salary = model.Salary,
                        IsActive = model.IsActive,
                        IsDeleted = model.IsDeleted,
                        HiringDate = model.HiringDate,
                        CreateAt = model.CreateAt


                    };
                    var Count = _employeeRepository.Add(employee);
                    if (Count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return View(model);
            }

            [HttpGet]
            public IActionResult Details(int? id, string ViewName = "Details")
            {
                if (id is null) return BadRequest("Invalid Id");
                var employee = _employeeRepository.Get(id.Value);
                if (employee is null) return NotFound(new { StatusCode = 400, Message = "$Employee With id :{id} is not found" });
                return View(ViewName, employee);
            }

            [HttpGet]
            public IActionResult Edit(int? id)
            {
               
                return Details(id, "Edit");

            }

            [HttpPost]
            public IActionResult Edit(Employee model)
            {
                if (ModelState.IsValid)
                {
                    var employee = _employeeRepository.Get(model.Id);
                    if (employee is null) return NotFound(new { StatusCode = 400, Message = "$Employee With id :{model.Id} is not found" });
                    employee.Name = model.Name;
                    employee.Age = model.Age;
                    employee.Email = model.Email;
                    employee.Address = model.Address;
                    employee.Phone = model.Phone;
                    employee.Salary = model.Salary;
                    employee.IsActive = model.IsActive;
                    employee.IsDeleted = model.IsDeleted;
                    employee.HiringDate = model.HiringDate;
                    employee.CreateAt = model.CreateAt;

                    var Count = _employeeRepository.Update(employee);
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
                
                return Details(id, "Delete");
            }
            [HttpPost]
            public IActionResult Delete(Employee model)
            {
                var employee = _employeeRepository.Get(model.Id);
                if (employee is null) return NotFound(new { StatusCode = 400, Message = "$Employee With id :{model.Id} is not found" });
                var Count = _employeeRepository.Delete(employee);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
    }
}
