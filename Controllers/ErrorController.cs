using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeMangement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        /// <summary>
        ///  62 Logging Exception in Asp.net Core//
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        //close 62
        [Microsoft.AspNetCore.Mvc.Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHnadler(int statusCode)
        {
            var stsuscoderesult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.message = "sorry the resource you requested not found";
                    //add code 62 looger here//
                    logger.LogWarning($"404 Error occured path={stsuscoderesult.OriginalPath}"+
                        $"and querystring={stsuscoderesult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");

        }
        [Microsoft.AspNetCore.Mvc.Route("Error")]
        [AllowAnonymous]
        public ActionResult Error()
        {
            var exceptiondetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //START 62 COOMENT CODE//
            //ViewBag.ExceptionPath = exceptiondetails.Path;
            //ViewBag.excemessage = exceptiondetails.Error.Message;

            //ViewBag.Stacktrace = exceptiondetails.Error.StackTrace;
            logger.LogError($"The path { exceptiondetails.Path} " +
                $"threw exception{exceptiondetails.Error}");


            return View("Error");
        }
    }
}


