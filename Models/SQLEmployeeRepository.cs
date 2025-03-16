using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMangement.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeMangement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext dbcontext;
        private readonly ILogger looger;

        public SQLEmployeeRepository(AppDbContext dbcontext,ILogger<SQLEmployeeRepository> looger)
        {
            this.dbcontext = dbcontext;
            this.looger = looger;
        }

        //public ILogger Looger { get; }

        public Employee Add(Employee employee)
        {
            dbcontext.Employees.Add(employee);
            dbcontext.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = dbcontext.Employees.Find(id);
            if (employee != null)
            {
                dbcontext.Employees.Remove(employee);
                dbcontext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {

            //part 64 looger//
            looger.LogTrace("Trace Log");
            looger.LogDebug("Debug Log");
            looger.LogInformation("Information Log");
            looger.LogWarning("Warning Log");
            looger.LogError("Error Log");
            looger.LogCritical("Critical Log");
            //close 64 looger//
            return dbcontext.Employees.Find(Id);
           
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return dbcontext.Employees;
        }

        public Employee Update(Employee employee)
        {
            var Employee = dbcontext.Employees.Attach(employee);
            Employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
            return employee;
        }
    }
}
