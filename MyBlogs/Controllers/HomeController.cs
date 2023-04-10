using Microsoft.AspNetCore.Mvc;
using StaffManagment.Models;
using StaffManagment.ViewModels;
namespace StaffManagment.Controllers;
public class HomeController : Controller
{
    private readonly IStaffRepository _staffRepasitory;
    private readonly IWebHostEnvironment webHost;
    public HomeController(IStaffRepository staffRepository, IWebHostEnvironment webHost)
    {
        _staffRepasitory = staffRepository;
        this.webHost = webHost;
    }
    public ViewResult Index()
    {
        return View(new HomeFullViewModel()
        {
            staffs = _staffRepasitory.GetAll()
        });
    }
    public ViewResult Detels(int id)
    {
        var staff = _staffRepasitory.Get(id);
        if(staff != null)
        {
            ViewBag.staff = staff;
            ViewBag.title = "Staff detals";
            return View();
        }
        else
        {
            return NotFaundView(id);
        }
    }
    [HttpGet]
    public ViewResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(HomeCreateViewModel staff)
    {
        string uniqueFileName = ProcessUploadedFile(staff);
        Staff newStaff = new Staff()
        {
            FirstName = staff.FirstName,
            LastName = staff.LastName,
            Email = staff.Email,
            Department = staff.Department,
            PhotoFilePath = uniqueFileName
        };
        if (ModelState.IsValid)
        {
            newStaff = _staffRepasitory.Create(newStaff);
            return RedirectToAction("Detels", new { id = newStaff.Id });
        }
        return View();
    }
    [HttpGet]
    public ViewResult Edit(int id)
    {
        Staff staff = _staffRepasitory.Get(id);
        if(staff != null)
        {
            HomeEditViewModel editViewModel = new HomeEditViewModel()
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Email = staff.Email,
                Department = staff.Department,
                ExistingPhotoFilePath = staff.PhotoFilePath
            };
            return View(editViewModel);
        }
        else
        {
            return NotFaundView(id);
        }
    }
    [HttpPost]
    public IActionResult Edit(HomeEditViewModel staff)
    {
        if (ModelState.IsValid)
        {
            Staff existingStaff = _staffRepasitory.Get(staff.Id);
            existingStaff.FirstName = staff.FirstName;
            existingStaff.LastName = staff.LastName;
            existingStaff.Email = staff.Email;
            existingStaff.Department = staff.Department;
            if(staff.Photo != null)
            {
                if (staff.ExistingPhotoFilePath != null)
                {
                    string filePath = Path.Combine(webHost.WebRootPath, "images",staff.ExistingPhotoFilePath);
                    //System.IO.File.Delete(filePath);
                }
                existingStaff.PhotoFilePath = ProcessUploadedFile(staff);
            }
            _staffRepasitory.Update(existingStaff);
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var staff = _staffRepasitory.Get(id);
        if (staff != null)
        {
            _staffRepasitory.Delete(id);
            if(staff.PhotoFilePath != null)
            {
                string filePath = Path.Combine(webHost.WebRootPath, "images", staff.PhotoFilePath);
                System.IO.File.Delete(filePath);
            }
            return RedirectToAction("Index");
        }
        else
        {
            return NotFaundView(id);
        }
    }

    private ViewResult NotFaundView(int id)
    {
        Response.StatusCode = 404;
        return View("StaffNotFaund",id);
    }

    private string ProcessUploadedFile(HomeCreateViewModel staff)
    {
        string uniqueFileName = string.Empty;
        if (staff.Photo != null)
        {
            string uplodeFolder = Path.Combine(webHost.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.Photo.FileName;
            string imageFilePath = Path.Combine(uplodeFolder, uniqueFileName);
            staff.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
        }

        return uniqueFileName;
    }
}