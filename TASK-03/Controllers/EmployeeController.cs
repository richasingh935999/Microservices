using Microsoft.AspNetCore.Mvc;
using Task03.Models;
using System.Collections.Generic;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {

        IEmployeeRepository _employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> empList = _employee.GetAllEmployees();
            return View(empList);
        }

        public IActionResult Details(int id)
        {
            Employee obj = _employee.GetEmployeeByID(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Employee obj)
        {
            _employee.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            Employee obj = _employee.GetEmployeeByID(id);
            return View(obj);
        }

        [HttpPost]

        public IActionResult Edit(Employee obj)
        {
            _employee.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _employee.GetEmployeeByID(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteEmp(int id)
        {
            _employee.DeleteEmployee(id);
            return RedirectToAction("Index");
        }



    }
}