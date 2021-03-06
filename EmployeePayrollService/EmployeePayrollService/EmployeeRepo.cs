using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = "Data Source = DESKTOP-7KANMDE\\SQLEXPRESS;Initial Catalog = empPayroll;";
        SqlConnection connection = new SqlConnection(connectionString);
        public DataSet Connectivity()
        {
            try
            {
                DataSet data = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("ConnectivityCheck", this.connection);
                    adapter.Fill(data);
                    this.connection.Close();
                    Console.WriteLine("Connection Established");
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void GetAllEmployee()
        {
            try
            {
                EmployeePayroll_Model model = new EmployeePayroll_Model(id: 0, name: null, salary: 0, startDate: DateTime.Now, gender: null,
                                    mobile: 0, address: null, department: null, basicPay: 0, deductions: 0, taxablePay: 0, netPay: 0);
                using (this.connection)
                {
                    string query = @"SELECT ID,NAME,SALARY,START_DATE,GENDER,MOBILE,ADDRESS,DEPARTMENT,BASIC_PAY,DEDUCTIONS,TAXABLE_PAY,NET_PAY
                                FROM EMPLOYEE_PAYROLL;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.id = reader.GetInt32(0);
                            model.name = reader.GetString(1);
                            model.salary = reader.GetDouble(2);
                            model.startDate = reader.GetDateTime(3);
                            model.gender = reader.GetString(4);
                            model.mobile = reader.GetDecimal(5);
                            model.address = reader.GetString(6);
                            model.department = reader.GetString(7);
                            model.basicPay = reader.GetDouble(8);
                            model.deductions = reader.GetDouble(9);
                            model.taxablePay = reader.GetDouble(10);
                            model.netPay = reader.GetDouble(11);

                            Console.WriteLine("Employee ID: " + model.id + "\n" + "Name: " + model.name + "\n" + "Start Date: " + model.startDate + "\n" + "Gender: " + model.gender + "\n" +
                               "Phone: " + model.mobile + "\n" + "Address: " + model.address + "\n" + "Department: " + model.department + "\n" + "Net Pay: " + model.netPay);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddEmployee(EmployeePayroll_Model model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NAME", model.name);
                    command.Parameters.AddWithValue("@SALARY", model.salary);
                    command.Parameters.AddWithValue("@START_DATE", model.startDate);
                    command.Parameters.AddWithValue("@GENDER", model.gender);
                    command.Parameters.AddWithValue("@MOBILE", model.mobile);
                    command.Parameters.AddWithValue("@ADDRESS", model.address);
                    command.Parameters.AddWithValue("@DEPARTMENT", model.department);
                    command.Parameters.AddWithValue("@BASIC_PAY", model.basicPay);
                    command.Parameters.AddWithValue("@DEDUCTIONS", model.deductions);
                    command.Parameters.AddWithValue("@TAXABLE_PAY", model.taxablePay);
                    command.Parameters.AddWithValue("@NET_PAY", model.netPay);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateTable()
        {
            try
            {
                using (this.connection)
                {
                    Console.WriteLine("Enter a Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Salary to Update");
                    double salary = Convert.ToDouble(Console.ReadLine());
                    SqlCommand command = new SqlCommand("UpdateEmployee_Payroll", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NAME", name);
                    command.Parameters.AddWithValue("@BASIC_PAY", salary);
                    this.connection.Open();
                    command.ExecuteNonQuery();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void DeleteData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    Console.WriteLine("Enter a Name");
                    string name = Console.ReadLine();
                    SqlCommand command = new SqlCommand("DeleteEmployee_Payroll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NAME", name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void AddMultipleEmployees(List<EmployeePayroll_Model> model)
        {
            model.ForEach(data =>
            {
                Console.WriteLine("Employees being Added");
                this.AddEmployee(data);
                Console.WriteLine("Employees Added " + data.name);
            });
        }
        public void AddEmployeesWithThreading(List<EmployeePayroll_Model> model)
        {
            model.ForEach(data =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Thread Start Time: " + DateTime.Now);
                    this.AddEmployee(data);
                    Console.WriteLine("Employee Added: " + data.name);
                    Console.WriteLine("Thread End Time: " + DateTime.Now);
                });
                thread.Start();
            });
        }
    }
}
