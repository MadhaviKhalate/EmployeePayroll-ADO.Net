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
            Assert.AreEqual(3, list.Count);
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
    }
}