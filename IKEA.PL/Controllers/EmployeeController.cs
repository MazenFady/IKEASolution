using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.BLL.Services.DepartmentService;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Models.Shared;
using IKEA.PL.ViewModels.DepartmentVms;
using IKEA.PL.ViewModels.EmployeeVms;
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
        public IActionResult Create() => View();
        
        [HttpPost]
        public IActionResult Create(EmployeeViewModel Vm)
        {
            if (ModelState.IsValid)
            {
                CreatedEmployeeDto dto = new CreatedEmployeeDto()
                {
                    Name = Vm.Name,
                    Age = Vm.Age,
                    Address = Vm.Address,
                    Salary = Vm.Salary,
                    IsActive = Vm.IsActive,
                    Email = Vm.Email,
                    PhoneNumber = Vm.PhoneNumber,
                    HiringDate = Vm.HiringDate,

                };

                try
                {
                    int Result = employeeServices.AddEmployee(dto);
                    if (Result > 0) return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can't Be Created");
                        return View(Vm);
                    }

                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment())
                    {
                        logger.LogError(ex.Message);
                        return View(Vm);
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            else
            {
                return View(Vm);
            }
        }
        [HttpGet]
        public IActionResult Details([FromRoute] int? id)
        {
            if (id == null) return BadRequest();
            var Employee = employeeServices.GetEmployeeById(id.Value);
            if (Employee == null) return NotFound();

            var ViewEmployee = new EmployeeViewModel()
            {
                Id = id.Value,
                Name = Employee.Name,
                Email = Employee.Email,
                PhoneNumber = Employee.PhoneNumber,
                Address = Employee.Address,
                Age = Employee.Age,
                Gender = (Gender)Enum.Parse(typeof(Gender), Employee.Gender),
                Salary = Employee.Salary,
                IsActive = Employee.IsActive,
                HiringDate = Employee.HiringDate,
                EmployeeType = (EmployeeType)Enum.Parse(typeof(EmployeeType), Employee.EmployeeType),

            };
            return View(Employee );
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var Employee = employeeServices.GetEmployeeById(id.Value);
            if (Employee == null) return NotFound();

            var ViewEmployee = new EmployeeViewModel()
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
        public IActionResult Edit([FromRoute]int? id, EmployeeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var Message = String.Empty;
            var employeeDto = new UpdatedEmployeeDto()
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                Address = model.Address,
                Salary = model.Salary,
                IsActive = model.IsActive,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                HiringDate = model.HiringDate,
                EmployeeType = model.EmployeeType,
                Gender = model.Gender
            };

            try
            {
                int Result = employeeServices.UpdateEmployee(employeeDto);
                if (Result > 0) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can't Be Created");
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                    return View(model);
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