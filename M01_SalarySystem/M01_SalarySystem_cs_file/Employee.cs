using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp1
{
    class Employee : Person   // derived class (child)
    {
        //Calculate the basic pay-period exemption = basic yearly exemption (3500) / PAY_PERIOD
        private const decimal BASIC_PAY_PERIOD_EXEMPTION = 3500;/* The basic yearly exemption ($3,500 for 2021) by the number */
        private const decimal PAY_PERIOD = 26;
        private const decimal EMPLOYEE_CONTRIBUTION = 0.0545m;
        public const decimal EI = 889.54m;  /*The maximum EI premiums in 2021 :889.54m*/
        

        /*Calculate the CPP which employee have to deduct from the Bi-weekly gross salary in 26 times a year*/
        public decimal CPP(decimal salary, decimal benefit_c)
        {
            Salary = salary;
            benefit = benefit_c;
            decimal cpp_annual;
            decimal cpp_contributions;
            decimal deducted_basic_pay_period;
            decimal pensionable_income;
            pensionable_income = Salary + benefit;
            deducted_basic_pay_period = pensionable_income - BASIC_PAY_PERIOD_EXEMPTION;
            cpp_contributions = deducted_basic_pay_period * EMPLOYEE_CONTRIBUTION;
            if (cpp_contributions > BASIC_PAY_PERIOD_EXEMPTION)
            {
                cpp_annual = BASIC_PAY_PERIOD_EXEMPTION;
                return cpp_annual;
            }
            else
            {
                cpp_annual = cpp_contributions;
                return cpp_annual;
            }
            return 0;  
        }

        /*Calculate Fedral Tax */
        public decimal FedTax(decimal taxble_income)
        {
            var fed_tax_rate = new List<decimal> { 0.15m, 0.205m, 0.26m, 0.29m, 0.33m };
            decimal getTaxRate;
            decimal federal_tax;
            decimal income = taxble_income;
            
            
            foreach (decimal taxRate in fed_tax_rate)
            {
                if (taxble_income < 49020)
                {
                    getTaxRate = fed_tax_rate[0];
                    /*Console.Write($"{getTaxRate} ");*/
                    federal_tax = (income - 0) * getTaxRate + 0;                    
                    return federal_tax;
                }
                else if (taxble_income > 49020 && taxble_income <= 98040)
                {
                    getTaxRate = fed_tax_rate[1];
                    /*Console.Write($"{getTaxRate} ");*/
                    federal_tax = (income - 49020) * getTaxRate + 7353;
                    return federal_tax;
                }
                else if (taxble_income > 98040 && taxble_income <= 151978)
                {
                    getTaxRate = fed_tax_rate[2];
                    /*Console.Write($"{getTaxRate} ");*/
                    federal_tax = (income - 98040) * getTaxRate + 17402.10m;
                    return federal_tax;
                }
                else if (taxble_income > 151978 && taxble_income <= 216511)
                {
                    getTaxRate = fed_tax_rate[3];
                    /*Console.Write($"{getTaxRate} ");*/
                    federal_tax = (income - 151978) * getTaxRate + 31425.98m;
                    return federal_tax;
                }
                else
                {
                    getTaxRate = fed_tax_rate[4];
                    /*Console.Write($"{getTaxRate} ");*/
                    federal_tax = (income - 216511) * getTaxRate + 50140.55m;
                    return federal_tax;
                }               
            }

            return 0;

        }

        /*Calculate Nova Scotia Tax */
        public decimal NSTax(decimal ns_taxble_income)
        {
            var ns_tax_rate = new List<decimal> { 0.0879m, 0.1495m, 0.1667m, 0.175m, 0.21m };
            decimal getNSTaxRate;
            decimal ns_tax;
            
            foreach (decimal taxRate in ns_tax_rate)
            {
                if (ns_taxble_income <= 29590)
                {
                    getNSTaxRate = ns_tax_rate[0];
                    /*Console.Write($"{getNSTaxRate} ");*/
                    ns_tax = (ns_taxble_income - 0) * getNSTaxRate + 0;
                    return ns_tax;
                }
                else if (ns_taxble_income > 29590 && ns_taxble_income <= 59180)
                {
                    getNSTaxRate = ns_tax_rate[1];
                    /*Console.Write($"{getNSTaxRate} ");*/
                    ns_tax = (ns_taxble_income - 29590) * getNSTaxRate + 2601;
                    return ns_tax;
                }
                else if (ns_taxble_income > 59180 && ns_taxble_income <= 93000)
                {
                    getNSTaxRate = ns_tax_rate[2];
                    /*Console.Write($"{getNSTaxRate} ");*/
                    ns_tax = (ns_taxble_income - 59180) * getNSTaxRate + 7025;
                    return ns_tax;
                }
                else if (ns_taxble_income > 93000 && ns_taxble_income <= 150000)
                {
                    getNSTaxRate = ns_tax_rate[3];
                    /*Console.Write($"{getNSTaxRate} ");*/
                    ns_tax = (ns_taxble_income - 93000) * getNSTaxRate + 12662;
                    return ns_tax;
                }
                else
                {
                    getNSTaxRate = ns_tax_rate[4];
                    /*Console.Write($"{getNSTaxRate} ");*/
                    ns_tax = (ns_taxble_income - 150000) * getNSTaxRate + 22637;
                    return ns_tax;
                }

            }

            return 0;
        }

        public decimal Gross_Salary
        {
            get { return Salary; }
            set { Salary = value; }
        }

        public decimal Benefit
        {
            get { return benefit; }
            set { benefit = value; }
        }

        public decimal Performance_Rating
        {
            get { return PerformanceRating; }
            set { PerformanceRating = value; }
        }

        /*Calculate paystub*/
        public override decimal ComputePayCheck(decimal cpp_value, decimal fed_tax, decimal ns_tax)
        {
            decimal payCheck;
            decimal cpp_ = cpp_value;       
            decimal federal_tax = fed_tax;
            decimal NS_tax = ns_tax;
            payCheck = Salary - federal_tax - NS_tax - cpp_ - EI;

            return payCheck;

        }

        /*Calculate pay rise*/
        public override decimal ComputePayRaise(decimal salary, decimal performanceRating)
        {
            Salary = salary;
            Performance_Rating = performanceRating;
            decimal rised_salary = Salary * Performance_Rating;
            return rised_salary;
        }
    }



}
