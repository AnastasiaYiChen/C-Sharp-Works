using System;
using System.Collections;

namespace ConsoleApp1
{
    abstract class Program
    {
        public static void Main(string[] args)
        {

            var employee = new Employee();
            var average_Employee = new AverageEmployee("Yi", "Chen", "Dartmouth", 44000, 0.3m);
            var programmer = new Programmer("Anna", "Sage", "Dartmouth", 83000, 0.9m);
            var manager = new Manager("Amily", "Zhang", "Dartmouth", 150000, 0.5m);
           
            // Creates and initializes a new ArrayList.
            ArrayList myAL = new ArrayList();
            myAL.Add(average_Employee.Salary);
            myAL.Add(programmer.Salary);
            myAL.Add(manager.Salary);

            ArrayList myARL = new ArrayList();
            myARL.Add(average_Employee.PerformanceRating);
            myARL.Add(programmer.PerformanceRating);
            myARL.Add(manager.PerformanceRating);
            Console.WriteLine(" ____________________________________________________________________________________      ");
            Console.WriteLine($"|AverageEmployee First name | {average_Employee.Firstname}      | Lastname | {average_Employee.Lastname}    | the address | {average_Employee.Address} | the salary is: {average_Employee.Salary} |");
            Console.WriteLine($"|Programmer First name      | {programmer.Firstname}    | Lastname | {programmer.Lastname}    | the address | {programmer.Address} | the salary is: {programmer.Salary} |");
            Console.WriteLine($"|manager First name         | {manager.Firstname}   | Lastname | {manager.Lastname}   | the address | {manager.Address} | the salary is: {manager.Salary} |");

            Console.WriteLine(" ____________________________________________________________________________________      " );
            Console.WriteLine("       Paystub " + "      | " + "       Pay Rising ");
            Console.WriteLine(" ____________________________________________________________________________________      ");
            Console.Write("      " + "        ");
            foreach (decimal riseRate in myARL)
            {
                Console.Write("       |" + "        " + riseRate +  "     ");
            }
            Console.WriteLine();
            foreach (decimal grossySalary in myAL)
            {
                Console.Write("        " + grossySalary + "        |");
                foreach (decimal riseRate in myARL)
                {
                    var paystub = employee.ComputePayCheck(employee.CPP(grossySalary, 600), employee.FedTax(grossySalary), employee.NSTax(grossySalary));
                    var payRising = employee.ComputePayRaise(grossySalary, riseRate);
                    Console.Write("         " + payRising + "       |");
                }
                Console.WriteLine("         ");
            }
            Console.WriteLine(" ____________________________________________________________________________________      ");
            Console.ReadLine();
        }

        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }
    }
}
