using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Manager : Employee //derived from Employee (child of Employee)
    {
        public Manager(string firstName, string lastname, string address, decimal salary, decimal performanceRating)
        {
            Firstname = firstName;
            Lastname = lastname;
            Address = address;
            Salary = salary;
            PerformanceRating = performanceRating;

        }
    }

}
