using Microsoft.AspNetCore.Mvc;
using MyBlogs.Models;
using MyBlogs.ViewModels;
using System.Text.Json.Serialization;

namespace MyBlogs.Controllers;

public class HomeController : Controller
{
    private readonly IStaffRepository _staffRepasitory;

    public HomeController(IStaffRepository staffRepository)
    {
        _staffRepasitory = staffRepository;
    }
    public ViewResult Index()
    {
        return View();
    }
    public ViewResult Full()
    {
        return View(new HomeFullViewModel()
        {
            staffs = _staffRepasitory.GetAll()
        });
    }
    public ViewResult one()
    {
        return View("../other/view1ml");
    }
    public ViewResult Detels(int id)
    {
        var staff = _staffRepasitory.Get(id);
        ViewData["staff"] = staff;
        ViewData["title"] = "Staff detals";
        return View();
    }
    public ViewResult Detelss(int id = 1)
    {
        var staff = _staffRepasitory.Get(id);
        ViewBag.title = "Staff detals";
        return View(staff);
    }
    public ViewResult Detelsss(int? id)
    {
        var staff = _staffRepasitory.Get(id??1);
        ViewBag.staff = staff;
        ViewBag.title = "Staff detals";
        return View();
    }
    public JsonResult Data()
    {
        return Json(new { id = 1, name = "zazaz" });
    }
    public string Staff()
    {
        return _staffRepasitory.Get(3)?.FirstName;
    }
}
