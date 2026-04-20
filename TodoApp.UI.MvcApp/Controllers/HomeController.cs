using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.UI.MvcApp.Models;

namespace TodoApp.UI.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
