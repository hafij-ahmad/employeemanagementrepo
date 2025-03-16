using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
       IEnumerable<Employee> GetEmployeeList();//Display value in table or list
        // vedieo 41//
        Employee Add(Employee employee);
        //vedio 49 repository pattern//
        Employee Update(Employee employee);
        Employee Delete(int id);
    }
}
