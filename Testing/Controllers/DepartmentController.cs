using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository repo;
        public DepartmentController(IDepartmentRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var dept = repo.GetAllDepartments();

            return View(dept);
        }

    }
}
