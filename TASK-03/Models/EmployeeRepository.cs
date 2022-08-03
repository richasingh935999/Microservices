using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task03.Models
{
    public  class EmployeeRepository : IEmployeeRepository
    
    {
        private readonly EmployeeDBContext db;

        public EmployeeRepository(EmployeeDBContext context)
        {
            db = context;
        }

        //implementation codes here..

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees;
        }

        public Employee GetEmployeeByID(int Id)
        {
            return db.Employees.Find(Id);
        }

        public Employee AddEmployee(Employee Emp)
        {
            db.Employees.Add(Emp);
            db.SaveChanges();
            return Emp;
        }

        public Employee UpdateEmployee(Employee eupd)
        {
            var employee = db.Employees.Attach(eupd);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return eupd;

            //alternatively we can check individual property state

            //db.Employees.Attach(eupd);
            //var entry = db.Entry(eupd);
            //entry.Property(e => e.Name).IsModified = true;
            ////same way for all properties
            //entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //db.SaveChanges();
        }

        public Employee DeleteEmployee(int Id)
        {
            Employee e = db.Employees.Find(Id);
            if (e != null)
            {
                db.Employees.Remove(e);
                db.SaveChanges();
            }
            return e;
        }
    }
}
