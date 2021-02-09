using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class AverageEmployee : Employee //derived from Employee (child of Employee)
    {

        public AverageEmployee(string firstName, string lastname, string address, decimal salary, decimal performanceRating)
        {
            Firstname = firstName;
            Lastname = lastname;
            Address = address;
            Salary = salary;
            PerformanceRating = performanceRating;

        }



    }
}
