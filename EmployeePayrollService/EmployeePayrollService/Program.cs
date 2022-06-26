﻿using System;

namespace EmployeePayrollService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeRepo getMethod = new EmployeeRepo();
            EmployeePayroll_Model model = new EmployeePayroll_Model();
            Console.WriteLine("1 to Check SQL Connectivity\n2 to Add Data to DB\n3 to view DB\n4 to Update DB\n5 to Delete Data from Table" +
                "\nEnter a Number");
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    {
                        getMethod.Connectivity();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter Name");
                        model.name = Console.ReadLine();
                        Console.WriteLine("Enter Salary");
                        model.salary = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter a Year,Month,Date");
                        model.startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter Gender");
                        model.gender = Console.ReadLine(); ;
                        Console.WriteLine("Enter Phone Number");
                        model.mobile = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter Address");
                        model.address = Console.ReadLine(); ;
                        Console.WriteLine("Enter Department");
                        model.department = Console.ReadLine(); ;
                        Console.WriteLine("Enter Basic Pay");
                        model.basicPay = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Dedutions");
                        model.deductions = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Taxable Pay");
                        model.taxablePay = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Net Pay");
                        model.netPay = Convert.ToDouble(Console.ReadLine());
                        getMethod.AddEmployee(model);
                        break;
                    }
                case 3:
                    {
                        getMethod.GetAllEmployee();
                        break;
                    }
                case 4:
                    {
                        getMethod.UpdateTable();
                        break;
                    }
                case 5:
                    {
                        getMethod.DeleteData();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter a valid Number");
                        break;
                    }
            }
        }
    }
}