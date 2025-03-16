using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models
{
    public static class ModelBuilderExtention
    {
        public static void Seed(  this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
              new Employee
              {
                  id = 1,
                  Name = "Mary",
                  Department = Dept.IT,
                  Email = "Mary@pragimtech.com"

              },

                 new Employee
                 {
                     id = 2,
                     Name = "John",
                     Department = Dept.HR,
                     Email = "John@pragimtech.com"

                 }


            );

        }
    }
}
