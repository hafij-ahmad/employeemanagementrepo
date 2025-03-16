using EmployeeMangement.Models;
using EmployeeMangement.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Microsoft.AspNetCore.Authorization;

//using System.Web.Mvc;
//using System.Web.Mvc;

namespace EmployeeMangement.Controllers
{
    // Inherit from Controller to get access to methods like View()
    //[Route("Home")]
    [Authorize]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private IHostingEnvironment _webHostEnvironment;
        private readonly ILogger logger;

       
        // Constructor with dependency injection
        public HomeController(IEmployeeRepository employeeRepository,IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger)
        {
            //part64 ASP.NET CORE LOGLEVEL
            //LogLevel(inject constructor Ilooger looger//

            //CLOSE 64//
            _employeeRepository = employeeRepository;
            _webHostEnvironment = hostingEnvironment;

            this.logger = logger;



        }

        //public IActionResult Get()
        //{
        //    _logger.LogInformation("This is an info message.");
        //    _logger.LogWarning("This is a warning message.");
        //    _logger.LogError("This is an error message.");
        //    return Ok();
        //}
        // Parameterless constructor (if needed)
        //public HomeController()
        //{
        //    _employeeRepository = new MockEmployeeRepository();
        //}
        ///Views/Home/Details.cshtml
        //public string Index()
        //{
        //    var model = _employeeRepository.GetEmployeeList();
        //    return "Hello from MVC";
        //}
        // Part 27 List in ASP.NET CORE MVC//

        [Route("~/Home")]
        [Route("~/")]
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetEmployeeList();
            return View(model);
        }
        //Part 33 Attribute routing asp.net core mv//
        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        //public ViewResult List()
        //{
        //    var model = _employeeRepository.GetEmployeeList();
        //    return View("~/Views/Home/Index.cshtml",model);
        //}
        public JsonResult Index1()
        {
            return new JsonResult(new { id = 1, Name = "Hafij Ahmad" });
        }

        public string EmployeeName()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        //public ViewResult Details()
        //{
        //    var model = _employeeRepository.GetEmployee(1);
        //    return View(model); // Now works because HomeController inherits from Controller
        //}
        //public ViewResult Details()
        //{
        //    var model = _employeeRepository.GetEmployee(1);
        //    return View("Test"); // Now works because HomeController inherits from Controller
        //}
        //part 22
        //public ViewResult Details()
        //{
        //    //    var model = _employeeRepository.GetEmployee(1);
        //    //    return View(model); // Now works because HomeController inherits from Controller
        //    //    var model = _employeeRepository.GetEmployee(1);
        //    //    return View("Test"); // Now works because HomeController inherits from Controller

        //    //var model = _employeeRepository.GetEmployee(1);
        //    //return View("MyView/Test1.cshtml"); // Now works because HomeController inherits from Controller
        //    //   var model = _employeeRepository.GetEmployee(1);
        //    //return View("../Test/Update");
        //    // Now works because HomeController inherits from Controller
        //    var model = _employeeRepository.GetEmployee(1);
        //   return View("../../MyView/Test1");
        //}
        //// close part22 
        ////part 23 Passing Data To Controller toView using ViewDta[]
        //public ViewResult Details()
        //{
        //    var model = _employeeRepository.GetEmployee(1);
        //    ViewData["Employee"] = model;
        //    ViewData["pagetitle"] = "Employee Details from viewdata";
        //    return View();
        //}
        ////part 23 Passing Data To Controller toView using ViewBag
        //public ViewResult Details()
        //{
        //    var model = _employeeRepository.GetEmployee(1);
        //    ViewBag.Employee = model;
        //    ViewBag.pagetitle = "Employee Details from viewbag";
        //    return View();
        //}
        ////part 24 Passing Data To Controller toView using strongly typed View
        //    public ViewResult Details()
        //    {
        //        var model = _employeeRepository.GetEmployee(1);

        //        ViewBag.pagetitle = "Employee Details from strongly typed view";
        //        return View(model);
        //}

        //part 26 Asp.net core ViewModel//
        //[Route("Home/Details/{id?}")]
        //public ViewResult Details(int? id)
        //{
        //    HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
        //    {
        //        Employee = _employeeRepository.GetEmployee(id ?? 1),
        //        PageTitle = "EmployeeDetails"

        //    };
        //   return  View(homeDetailsViewModel);
        //}

        //part 57 handling 404 notfound in asp.net core//
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            //vedieo 60 not comment new Exception("Error in details view");
            //throw new Exception("Error in details view");
            //vedieo 60 run//
            //64 Loglevet first comment throw new Exception("Error in details view");

            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");
            //close Loglevel 64//
            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if(employee==null)
            {
                Response.StatusCode = 404;
                return View("NotFound", id.Value);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"

            };
            return View(homeDetailsViewModel);
        }

        //close 57//
        public ObjectResult Details1()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return new ObjectResult(model);
        }
        //part 33 Attribute routing 
        //[Route("Home/Details/{id}")]
        //public ViewResult Details(int id)
        //{
        //   var  Employee = _employeeRepository.GetEmployee(id);
        //    return View(Employee);
        //}
        //public ViewResult List()
        //{
        //    var model = _employeeRepository.GetEmployeeList();
        //    return View("~/Views/Home/Index.cstml", model);
        //}
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Create()
        {
            return View();
        }

        // vedioe 55 Edit operation///
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
             Name=employee.Name,
             Email=employee.Email,
             Department=employee.Department,
             ExistingPhotoPath=employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }
        // close vedio55//
        
        // VIeoi 41 save data
        //[HttpPost]
        //public RedirectToActionResult Create(Employee employee)
        //{
        //    Employee newemployee = _employeeRepository.Add(employee);
        //    return RedirectToAction("Details",new { id = newemployee.id });
        //}
        // VIeoi 41 save data with validation//
        //[HttpPost]
        //public IActionResult Create(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee newemployee = _employeeRepository.Add(employee);
        //        //return RedirectToAction("Details", new { id = newemployee.id });
        //    }
        //    return View();
        //}
        // part 41 asp.net core Model Binding//
        public string Details2(int?id, string name)
        {
            return "id=" + id.Value.ToString() + "name=" + name;
        }

        // vedio 53 Upload photo copy and paste Create action method//
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(EmployeeCreateViewModel model)
       {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                uniqueFileName = ProcessUploadedFile(model);

                Employee NewEmployee = new Employee
                {

                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName

                };
                _employeeRepository.Add(NewEmployee);
                return RedirectToAction("Details", new { id = NewEmployee.id });
            }
            return View();
        }




        // vedio 53 Upload photo close//

        // vedieo 56 Udate view Model//
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                //step1 get employee//
                Employee employee = _employeeRepository.GetEmployee(model.id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                if (model.Photos != null)
                {
                    if(model.ExistingPhotoPath!=null)
                    {
                      string filepath = Path.Combine(_webHostEnvironment.WebRootPath,"Images",model.ExistingPhotoPath);
                        System.IO.File.Delete(filepath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }
                //Employee NewEmployee = new Employee
                //{

                //    Name = model.Name,
                //    Email = model.Email,
                //    Department = model.Department,
                //    PhotoPath = uniqueFileName

                //};
                _employeeRepository.Update(employee);
                return RedirectToAction("index", new { id = employee.id });
            }
            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {

                foreach (IFormFile photo in model.Photos)

                {
                    if (_webHostEnvironment == null)
                    {
                        // Log an error or throw a more specific exception
                        throw new InvalidOperationException("webHostEnvironment is not initialized.");
                    }

                    string Uploadfolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                    // Ensure the upload folder exists
                    if (!Directory.Exists(Uploadfolder))
                    {
                        Directory.CreateDirectory(Uploadfolder);
                    }

                    // Create a unique filename
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filepath = Path.Combine(Uploadfolder, uniqueFileName);

                    try
                    {
                        // Copy the file to the server
                        using (var fileStream = new FileStream(filepath, FileMode.Create))
                        {
                            photo.CopyTo(fileStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log the error or notify the user)
                        throw new Exception("An error occurred while uploading the file.", ex);
                    }
                }
            }

            return uniqueFileName;
        }
        //vedieo 56 Update view model//
    }

   
}
