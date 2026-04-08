using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Stack
{
    internal class Operation
    {
        private Stack<Employee>? _employees = default;
        private int id = 0;

        public Operation()
        {
            _employees = new Stack<Employee>();
        }

        private int GetTopEmployeeId()
        {
            bool isStackEmpty = !_employees.Any();

            try
            {
                if (isStackEmpty)
                {
                    id = _employees?.Peek()?.Id ?? 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                id++;
            }
            return id;
        }

        private (int Id, string Name, int Age, string City) GetNewEmployeeInformationFromUser()
        {
            Console.WriteLine("\n\nEnter Employee Details...\n");

            //Console.Write("Employee Id: ");

            /* Read Employee ID From User */
            //var isIdInteger = int.TryParse(Console.ReadLine(), out int employeeId);

            //if (!isIdInteger)
            //{
            int employeeId = GetTopEmployeeId();
            //}

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

        private void DisplayEmployeesDetail()
        {
            if (!_employees.Any())
            {
                Console.Write("No Employee Found!");
                return;
            }
            DisplayEmployeeDetails(employees: _employees);
        }

        private void DisplayTopEmployeeByName()
        {
            if (!_employees.Any())
            {
                Console.Write("No Employee Found!");
            }

            Employee topEmployee = _employees.Peek();

            Console.WriteLine("\nTop Employee Name: " + topEmployee.Name);
            Console.WriteLine();
        }

        private void GetChoiceDetail()
        {
            int choice = default;

            do
            {
                Console.WriteLine(" 1. Add Employee \n 2. Get Top Employee \n 3. Get Employee Details \n 4. Remove Employee \n 5. Exit \n");
                Console.Write("Enter Your Choice: ");
                var isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (isValidChoice)
                {
                    switch (choice)
                    {
                        case 1:
                            var addedEmployees = AddEmployee();
                            Console.WriteLine($"\nAdded Employee Details...");
                            Console.WriteLine("--------- --------- ---------\n");
                            DisplayEmployeeDetails(employees: addedEmployees);
                            Console.WriteLine("--------- --------- ---------\n");
                            break;

                        case 2:
                            DisplayTopEmployeeByName();
                            break;

                        case 3:
                            Console.WriteLine();
                            DisplayEmployeesDetail();
                            break;

                        case 4:
                            var remainingEmployee = RemoveEmployee();
                            Console.WriteLine("\nRemaining Employees After Removing...\n");
                            DisplayEmployeeDetails(employees: remainingEmployee);
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            }
            while (choice != 5);
        }

        private void DisplayEmployeeDetails(IEnumerable<Employee> employees)
        {
            if (!employees.Any())
            {
                Console.Write("\n--- No Employee Found! ---");
            }

            foreach (var employee in employees)
            {
                Console.Write("Id: " + employee.Id + " | Name: " + employee.Name + " | Age: " + employee.Age + " | City: " + employee.City);
                Console.WriteLine("\n");
            }
        }

        internal void Run()
        {
            GetChoiceDetail();
        }
    }
}
