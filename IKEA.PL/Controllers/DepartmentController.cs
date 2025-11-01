using Humanizer;
using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Services.DepartmentServices.DepartmentService;
using IKEA.PL.ViewModels.DepartmentVms;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    #region Services - DI
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices DepartmentServices;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment environment;

        public DepartmentController(IDepartmentServices department, ILogger<DepartmentController> logger, IWebHostEnvironment environment)
        {
            this.DepartmentServices = department;
            this.logger = logger;
            this.environment = environment;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var Depts = DepartmentServices.GetAllDepartments();
            return View(Depts);
        }
        #endregion

        #region Create
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = DepartmentServices.AddDepartment(dto);
                    if (Result > 0) return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't Be Created");
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
        #endregion
    

        #region Details

        [HttpGet]
        public IActionResult Details([FromRoute] int? id)
        {
            if (id == null) return BadRequest();
            var Department = DepartmentServices.GetDepartmentById(id.Value);
            if (Department == null) return NotFound();

            return View(Department);
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var Department = DepartmentServices.GetDepartmentById(id.Value);
            if (Department == null) return NotFound();
            var ViewDepartment = new DepartmentViewModel
            {
                Id = id.Value,
                Name = Department.Name,
                Description = Department.Description,
                Code = Department.Code
            };

            return View(ViewDepartment);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, DepartmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var Department = new UpdatedDepartmentDto()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Code = model.Code

            };


            try
            {
                int Result = DepartmentServices.UpdateDepartment(Department);
                if (Result > 0) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Can't Be Created");
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
        #endregion

        #region Delete
            [HttpGet]
            public IActionResult Delete( int? id)
            {    
                if (!id.HasValue)
                    return BadRequest();
             var Department = DepartmentServices.GetDepartmentById(id.Value);
                if(Department is null)
                    return NotFound();
                return View(Department);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]    
            public IActionResult DeleteConfirmed(int id)
            {
                
              if (id == 0) return BadRequest();
                try
                {

                    bool IsDeleted = DepartmentServices.DeleteDepartment(id);
                    if(IsDeleted)
                    return RedirectToAction(nameof(Index));
                else ModelState.AddModelError(string.Empty, "Department Can't Be Deleted");
                    return RedirectToAction(nameof(Delete), new {  id });
                }
                catch (Exception ex)
                {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(ex); 
                }

                }
            }
        #endregion

    }
}
