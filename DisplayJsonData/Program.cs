using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1 - Read Json data from Json file and get the data in collction object
            //var jsonData = File.OpenText(@"EmployeeDetails.json");
            var jsonVariable = "[{\"empid\" : 1, \"salary\" : 100},{\"empid\" : 5, \"salary\" : 200},{\"empid\" : 4, \"salary\" : 300},{\"empid\" : 3, \"salary\" : 400},{\"empid\" : 2, \"salary\" : 500}]";
            //var jsonVariable = @"[{""empid"" : 1, ""salary"" : 200}, {""empid"" : 2, ""salary"" : 250},{""empid"" : 3, ""salary"" : 300},{""empid"" : 1, ""salary"" : 200}]";

            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>
            (
                jsonVariable, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            // 2 - Sort the employees in descending order of their salary
            employees.Sort(delegate (Employee x, Employee y) {
                return y.Salary.CompareTo(x.Salary);
            });

            // Display sorting output
            foreach (var item in employees)
                Console.WriteLine("Emp Id - " + item.EmpId + " and Salary - " + item.Salary);

            // 3 - Read input data
            Console.WriteLine("Please enter index #");
            var empId = Console.ReadLine();

            // 4 - Fiter data based on user input
            var employee = employees[Convert.ToInt32(empId) - 1];

            Console.WriteLine(employee.EmpId + " - " + employee.Salary);
        }
    }

    class Employee
    {
        public int EmpId { get; set; }
        public int Salary { get; set; }
    }
}
