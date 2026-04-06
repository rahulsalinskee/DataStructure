using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Stack
{
    internal class Operation
    {
        private static Stack<Employee>? _employees = default;

        public Operation()
        {
            _employees = new Stack<Employee>();
        }

        private static (int Id, string Name, int Age, string City) GetEmployeeFromUser()
        {
            Console.WriteLine("Enter Employee Details...");

            Console.WriteLine("Employee Id: ");

            /* Read Employee ID From User */
            var id = int.TryParse(Console.ReadLine(), out int employeeId);

            Console.WriteLine("Employee Name: ");

            /* Read Employee Name From User */
            var name = Console.ReadLine();

            Console.WriteLine("Employee Age: ");

            /* Read Employee Age From User */
            var age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Employee City: ");

            /* Read Employee City From User */
            var city = Console.ReadLine();

            return (employeeId, name, age, city);
        }
        
        private static IEnumerable<Employee> AddEmployee()
        {
            var employee = GetEmployeeFromUser();

            _employees?.Push(new Employee() { Id = employee.Id, Name = employee.Name, Age = employee.Age, City = employee.City });

            return _employees;
        }

        private static IEnumerable<Employee> RemoveEmployee()
        {
            if (_employees.Any())
            {
                _employees.Pop();
            }

            return _employees;
        }

        private static void GetEmployee()
        {
            foreach (var employee in _employees)
            {
                Console.WriteLine("Id: " + employee.Id + " Name: " + employee.Name + " Age: " + employee.Age + " City: " + employee.City);
                Console.WriteLine();
            }
        }

        internal static void Run()
        {
            var employees = GetEmployee();

            Console.WriteLine("Count: " + employees.Count());
        }
    }
}
