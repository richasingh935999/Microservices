using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task03.Models
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeByID(int Id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employeechanges);
        Employee DeleteEmployee(int Id);
    }
}
