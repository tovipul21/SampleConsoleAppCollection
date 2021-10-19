using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1 - Read Json data from Json file and get the data in collction object
            var jsonFileReader = File.OpenText(@"C:\Accenture\EmployeeDetails.json");

            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

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
