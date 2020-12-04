using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

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
        public IActionResult ViewDepartment(int id)
        {
            var department = repo.GetDepartment(id);

            return View(department);
        }
        public IActionResult UpdateDepartment(int id)
        {
            Department dept = repo.GetDepartment(id);

            if (dept == null)
            {
                return View("DepartmentNotFound");
            }
            return View(dept);
        }
        public IActionResult UpdateDepartmentToDatabase(Department department)
        {
            repo.UpdateDepartment(department);

            return RedirectToAction("ViewDepartment", new { id = department.DepartmentID });
        }

        //not sure if this is needed --edit: this does work.. just do not include the category info that product tables had
        public IActionResult InsertDepartment()
        {
            var dept = repo.AssignDepartment();

            return View(dept);
        }
        //this is fine
        public IActionResult InsertDepartmentToDatabase(Department departmentToInsert)
        {
            repo.InsertDepartment(departmentToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteDepartment(Department department)
        {
            repo.DeleteDepartment(department);

            return RedirectToAction("Index");
        }
    }
}
