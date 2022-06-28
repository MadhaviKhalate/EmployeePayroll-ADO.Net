using System;

namespace EmployeePayrollService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeRepo getMethod = new EmployeeRepo();
            EmployeePayroll_Model model = new EmployeePayroll_Model(id: 0, name: null, salary: 0, startDate: DateTime.Now, gender: null,
                               mobile: 0, address: null, department: null, basicPay: 0, deductions: 0, taxablePay: 0, netPay: 0);
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
                case 6:
                    {
                        List<EmployeePayroll_Model> list = new List<EmployeePayroll_Model>();
                        list.Add(new EmployeePayroll_Model(id: 0, name: "Saniya", salary: 15000, startDate: new DateTime(2021, 05, 01), gender: "F", mobile: 9835646725, address: "Sangavi", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
                        list.Add(new EmployeePayroll_Model(id: 0, name: "Pallavi", salary: 15000, startDate: new DateTime(2021, 04, 01), gender: "F", mobile: 7864667742, address: "Phaltan", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
                        list.Add(new EmployeePayroll_Model(id: 0, name: "Pooja", salary: 15000, startDate: new DateTime(2021, 05, 01), gender: "F", mobile: 8873752538, address: "Baramati", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
                        list.Add(new EmployeePayroll_Model(id: 0, name: "Sonal", salary: 15000, startDate: new DateTime(2021, 06, 01), gender: "F", mobile: 9978453867, address: "Bhigwan", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
                        list.Add(new EmployeePayroll_Model(id: 0, name: "Sakshi", salary: 15000, startDate: new DateTime(2021, 03, 01), gender: "F", mobile: 8798656473, address: "Pandare", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
                        DateTime startTime = DateTime.Now;
                        getMethod.AddMultipleEmployees(list);
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