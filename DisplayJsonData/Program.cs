using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        static string jsonFilePath = @"EmployeeDetails.json";

        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to read or write the data? Choose 1 to read and 2 to write.");
            string readWriteChoice = Console.ReadLine();
            //var readWriteChoice = Console.ReadLine() ?? "1";

            switch (readWriteChoice)
            {
                // Read Json data
                case "1":
                    ReadJsonData();
                    break;
                // Write Json data
                case "2":
                    WriteIntoJsonFile();
                    break;
                default:
                    ReadJsonData();
                    break;
            }
        }

        private static void ReadJsonData()
        {
            // 1 - Read Json data from Json file and get the data in collction object
            var jsonData = File.ReadAllText(jsonFilePath);

            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>
            (
                jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            // 2 - Sort the employees in descending order of their salary
            employees = employees.OrderByDescending(emp => emp.Salary).ToList();

            // Display sorting output
            foreach (var emp in employees)
                Console.WriteLine("Emp Id - " + emp.EmpId + "; Name - " + emp.FirstName + " " + emp.LastName + "; Salary - " + emp.Salary);

            // 3 - Read input data
            Console.WriteLine("Please enter index #");
            var empId = Console.ReadLine();

            // 4 - Fiter data based on user input
            var employee = employees[Convert.ToInt32(empId) - 1];

            Console.WriteLine(employee.EmpId + " - " + employee.Salary);

            // 5 - Average salary
            double averageSalary = employees.Average(emp => emp.Salary);
            Console.WriteLine($"Average salary of all employees is {averageSalary}");

            // 6 - Aggregate salary
            //var aggregateSalary = employees.Aggregate<Employee, int>(0,(TotalSalary, emp) => TotalSalary += emp.Salary);
            //Console.WriteLine($"Total Salary of all employees is {aggregateSalary}");

            var allEmployeeName = employees.Aggregate<Employee, string>
                (
                    "Employee Name are as follows ",
                        (empName, emp) => empName += emp.FirstName + " " + emp.LastName + ", ");

            Console.WriteLine(allEmployeeName);
        }

        /// <summary>
        /// This method will insert ata into an Json file.
        /// </summary>
        private static void WriteIntoJsonFile()
        {
            // 1 - Read Json data from Json file and get the data in collection object
            var jsonData = File.ReadAllText(jsonFilePath);

            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>
            (
                jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            // 2 - Start reading user input to be put into the employee object
            var _empId = employees.Max(emp => emp.EmpId);

            // Get input for employee Salary
            int _salary = AskSalary("Please enter employee salary in integer format");

            // Get Employee First Name data
            Console.WriteLine("Please enter employee First Name");
            var _firstName = Console.ReadLine();

            // Get Employee Last Name data
            Console.WriteLine("Please enter employee Last Name");
            var _lastName = Console.ReadLine();

            employees.Add(new Employee()
            {
                EmpId = Convert.ToInt32(_empId) + 1,
                Salary = _salary,
                FirstName = _firstName,
                LastName = _lastName
            });

            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(jsonFilePath, json);
        }

        private static int AskSalary(string salaryQuestion)
        {
            Console.WriteLine(salaryQuestion);

            int _salary;

            var isSalaryNumber = Int32.TryParse(Console.ReadLine(), out _salary);

            while (!isSalaryNumber)
            {
                Console.WriteLine(salaryQuestion);
                //_salary = Console.ReadLine();

                isSalaryNumber = Int32.TryParse(Console.ReadLine(), out _);
            }

            return _salary;
        }
    }

    class Employee
    {
        public int EmpId { get; set; }
        public int Salary { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
