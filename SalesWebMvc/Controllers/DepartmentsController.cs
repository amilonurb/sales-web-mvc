using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System.Collections.Generic;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "Electronics" }
            };
            return View(departments);
        }
    }
}