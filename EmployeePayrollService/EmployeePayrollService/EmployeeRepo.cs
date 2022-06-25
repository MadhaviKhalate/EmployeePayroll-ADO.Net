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
    }
}