using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp1
{
    public abstract class Person // base class (parent)
    {
        public string Firstname; 
        public string Lastname;
        public string Address; 
        public decimal Salary;
        public decimal benefit;
        public decimal PerformanceRating;

       
        public abstract decimal ComputePayCheck(decimal cpp_value, decimal fed_tax, decimal ns_tax);

        public abstract decimal ComputePayRaise(decimal salary, decimal performanceRating);

    }

    
}
