using Microsoft.AspNetCore.Mvc;

namespace StaffManagment.Controllers;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]

    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        if(statusCode == 404)
        {
            ViewBag.ErrorMessage = "The recource you are looking for is not found";
        }
        return View("NotFound");
    }
}
