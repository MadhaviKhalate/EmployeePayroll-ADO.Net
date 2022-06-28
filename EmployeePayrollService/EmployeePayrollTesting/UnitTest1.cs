using EmployeePayrollService;

namespace EmployeePayrollTesting
{
    
    public class Tests
    {
       
        EmployeeRepo getMethod = new EmployeeRepo();
        [Test]
        public void GivenMultipleEmployeeDetails_ShouldReturnTatalExecutionTime()
        {
            List<EmployeePayroll_Model> list = new List<EmployeePayroll_Model>();
            list.Add(new EmployeePayroll_Model(id: 0, name: "Saniya", salary: 15000, startDate: new DateTime(2021, 05, 01), gender: "F", mobile: 9835646725, address: "Sangavi", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
            list.Add(new EmployeePayroll_Model(id: 0, name: "Pallavi", salary: 15000, startDate: new DateTime(2021, 04, 01), gender: "F", mobile: 7864667742, address: "Phaltan", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
            list.Add(new EmployeePayroll_Model(id: 0, name: "Pooja", salary: 15000, startDate: new DateTime(2021, 05, 01), gender: "F", mobile: 8873752538, address: "Baramati", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
            list.Add(new EmployeePayroll_Model(id: 0, name: "Sonal", salary: 15000, startDate: new DateTime(2021, 06, 01), gender: "F", mobile: 9978453867, address: "Bhigwan", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
            list.Add(new EmployeePayroll_Model(id: 0, name: "Sakshi", salary: 15000, startDate: new DateTime(2021, 03, 01), gender: "F", mobile: 8798656473, address: "Pandare", department: "Developer", basicPay: 15000, deductions: 200, taxablePay: 500, netPay: 14500));
            DateTime startTime = DateTime.Now;
            getMethod.AddMultipleEmployees(list);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Time Taken without Threading: " + (endTime - startTime));

            DateTime startTimewithThreading = DateTime.Now;
            getMethod.AddEmployeesWithThreading(list);
            DateTime endTimeWithThreading = DateTime.Now;
            Console.WriteLine("Time Taken with Threading: " + (endTimeWithThreading - startTimewithThreading));
        }
    }
}