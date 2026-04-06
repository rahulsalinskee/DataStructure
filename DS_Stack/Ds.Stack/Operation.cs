using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Stack
{
    internal class Operation
    {
        private Stack<Employee>? _employees = default;

        public Operation()
        {
            _employees = new Stack<Employee>();
        }

        private static (int Id, string Name, int Age, string City) GetNewEmployeeInformationFromUser()
        {
            Console.WriteLine("\n\nEnter Employee Details...\n");

            Console.Write("Employee Id: ");

            /* Read Employee ID From User */
            var id = int.TryParse(Console.ReadLine(), out int employeeId);

            Console.Write("\nEmployee Name: ");

            /* Read Employee Name From User */
            var name = Console.ReadLine();

            Console.Write("\nEmployee Age: ");

            /* Read Employee Age From User */
            var age = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEmployee City: ");

            /* Read Employee City From User */
            var city = Console.ReadLine();

            return (employeeId, name, age, city);
        }

        private IEnumerable<Employee> AddEmployee()
        {
            var employee = GetNewEmployeeInformationFromUser();

            _employees?.Push(new Employee() { Id = employee.Id, Name = employee.Name, Age = employee.Age, City = employee.City });

            return _employees;
        }

        private IEnumerable<Employee> RemoveEmployee()
        {
            if (!_employees.Any())
            {
                Console.WriteLine("No Employee Found!");
            }

            _employees.Pop();
            return _employees;
        }

        private void GetEmployeesDetail()
        {
            if (!_employees.Any())
            {
                Console.WriteLine("No Employee Found!");
                return;
            }
            foreach (var employee in _employees)
            {
                Console.WriteLine("Id: " + employee.Id + " Name: " + employee.Name + " Age: " + employee.Age + " City: " + employee.City);
                Console.WriteLine();
            }
        }

        private void GetTopEmployeeByName()
        {
            if (!_employees.Any())
            {
                Console.WriteLine("No Employee Found!");
            }

            Employee topEmployee = _employees.Peek();
            Console.WriteLine("Top Employee: " + topEmployee.Name);
        }

        private void GetChoiceDetail()
        {
            Console.WriteLine(" 1. Add Employee \n 2. Get Top Employee \n 3. Get Employee Details \n 4. Remove Employee \n 5. Exit \n");

            Console.Write("Enter Your Choice: ");
            var choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var addedEmployees = AddEmployee();
                    Console.WriteLine($"Added Employees...\n");

                    foreach (var employee in addedEmployees)
                    {
                        Console.Write("Id: " + employee.Id + " Name: " + employee.Name + " Age: " + employee.Age + " City: " + employee.City);
                        Console.WriteLine();
                    }

                    break;
                case 2:
                    GetTopEmployeeByName();
                    break;
                case 3:
                    GetEmployeesDetail();
                    break;
                case 4:
                    var remainingEmployee = RemoveEmployee();
                    Console.WriteLine("Remaining Employees After Removing...");

                    foreach (var employee in remainingEmployee)
                    {
                        Console.Write("Id: " + employee.Id + " Name: " + employee.Name + " Age: " + employee.Age + " City: " + employee.City);
                        Console.WriteLine();
                    }

                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        internal  void Run()
        {
            GetChoiceDetail();
        }
    }
}
