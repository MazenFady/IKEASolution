using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.BLL.Services.DepartmentService;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Models.Shared;
using IKEA.PL.ViewModels.DepartmentVms;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        private readonly ILogger<EmployeeController> logger;
        private readonly IWebHostEnvironment environment;

        public EmployeeController(IEmployeeServices employeeServices, ILogger<EmployeeController> logger, IWebHostEnvironment environment)
        {
            this.employeeServices = employeeServices;
            this.logger = logger;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var Employees = employeeServices.GetAllEmployees();
            return View(Employees);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = employeeServices.AddEmployee(dto);
                    if (Result > 0) return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can't Be Created");
                        return View(dto);
                    }

                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                    {
                        logger.LogError(ex.Message);
                        return View(dto);
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            else
            {
                return View(dto);
            }
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int? id)
        {
            if (id == null) return BadRequest();
            var Employee = employeeServices.GetEmployeeById(id.Value);
            if (Employee == null) return NotFound();

            return View(Employee );
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var Employee = employeeServices.GetEmployeeById(id.Value);
            if (Employee == null) return NotFound();

            var ViewEmployee = new UpdatedEmployeeDto()
            {
                Id = id.Value,
                Name = Employee.Name,
                Email = Employee.Email,
                PhoneNumber = Employee.PhoneNumber,
                Address = Employee.Address,
                Age = Employee.Age,
                Gender = (Gender)Enum.Parse(typeof(Gender),Employee.Gender),
                Salary = Employee.Salary,
                IsActive = Employee.IsActive,
                HiringDate = Employee.HiringDate,
                EmployeeType = (EmployeeType)Enum.Parse(typeof(EmployeeType), Employee.EmployeeType),


            };

            return View(ViewEmployee);
        }
        [HttpPost]
        public IActionResult Edit(UpdatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid) return View(employeeDto);
            var Message = String.Empty;
          
            try
            {
                int Result = employeeServices.UpdateEmployee(employeeDto);
                if (Result > 0) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can't Be Created");
                    return View(employeeDto);
                }

            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(employeeDto);
                }
                else
                {
                    throw;
                }

            }

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = employeeServices.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Message = string.Empty;
            try
            {
                var IsDeleted = employeeServices.DeleteEmployee(id);
                if (IsDeleted)
                    return RedirectToAction(nameof(Index));

                Message = "Employee Can't Be Deleted";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                Message = ex.Message;
            }
            ModelState.AddModelError(string.Empty, Message);
            return RedirectToAction(nameof(Index));
        }

    }
}