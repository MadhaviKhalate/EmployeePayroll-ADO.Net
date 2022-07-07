using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace RestSharp_Testing
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }
    [TestClass]
    public class RESTSharp
    {
        RestClient client;

        [TestMethod]
        public void OnCallingGetMethod_ShouldReturnEmployeeList()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Get);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(13, list.Count);
            foreach (Employee data in list)
            {
                Console.WriteLine("{0,-5}{1,-15}{2,-10}", data.id, data.name, data.salary);
            }
        }
        [TestMethod]
        public void OnPostingEmployeeData_ShouldAddtoJsonServer()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Post);
            var body = new Employee { name = "Praneeta", salary = "5000" };
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee data = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Praneeta", data.name);
            Assert.AreEqual("5000", data.salary);
            Console.WriteLine(response.Content);
        }
        [TestMethod]
        public void OnPostingMultipleEmployees_SholudAddToJsonServer()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { name = "Pallavi", salary = "40000" });
            list.Add(new Employee { name = "Nutan", salary = "50000" });
            list.Add(new Employee { name = "Pradeep", salary = "35000" });
            list.ForEach(body =>
            {
                RestRequest request = new RestRequest("/employees", Method.Post);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                //Act
                RestResponse response = client.Execute(request);
                //Assert
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                Employee data = JsonConvert.DeserializeObject<Employee>(response.Content);
                Assert.AreEqual(body.name, data.name);
                Assert.AreEqual(body.salary, data.salary);
                Console.WriteLine(response.Content);
            });
        }
        [TestMethod]
        public void OnUpdatingEmployeeData_ShouldUpdateOnJsonServer()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees/7", Method.Put);
            List<Employee> list = new List<Employee>();
            Employee body = new Employee { name = "Sayali", salary = "25000" };
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Employee data = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Sayali", data.name);
            Assert.AreEqual("25000", data.salary);
            Console.WriteLine(response.Content);
        }
        [TestMethod]
        public void OnDeletingEmployeeData_ShouldDeleteOnJsonServer()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees/13", Method.Delete);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Console.WriteLine(response.Content);
        }
    }
}