using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                //new Employee() { id = 1, Name = "Mary",Email="Mary@pragamtech.com", Department = "HR" },
                //new Employee() { id = 2, Name = "John", Email="John@pragamtech.com", Department = "IT" },
                //new Employee() { id = 3, Name = "Sam", Email="Mary@pragamtech.com", Department = "IT" },
                // Vedio 40 dEPT
                 //new Employee() { id = 0, Name = "Mary",Email="Mary@pragamtech.com", Department = Dept.None},
                new Employee() { id = 1, Name = "Mary",Email="Mary@pragamtech.com", Department = Dept.HR},
                new Employee() { id = 2, Name = "John", Email="John@pragamtech.com", Department = Dept.IT},
                new Employee() { id = 3, Name = "Sam", Email="Mary@pragamtech.com", Department = Dept.Payroll},

            };

        }

        public Employee Add(Employee employee)
        {
            employee.id=_employeeList.Max(e => e.id)+1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.id == id);
            if(employee!=null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.id == Id);
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return _employeeList.ToList();
        }

        public Employee Update(Employee employee)
        {
            Employee employee1 = _employeeList.FirstOrDefault(e => e.id == employee.id);
            if (employee1 != null)
            {
                employee1.Name = employee.Name;
                employee1.Email = employee.Email;
                employee1.Department = employee.Department;
            }
            return employee;
        }
    }
}
