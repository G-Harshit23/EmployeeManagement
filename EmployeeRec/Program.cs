using EmployeeRec.Data;
namespace EmployeeRec  
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeContext context = new EmployeeContext();
            EmployeeFunctionalities EmployeeFunctionalities = new EmployeeFunctionalities(context);


            while (true)
            {
                try
                {

                    int n = 0;
                    Console.WriteLine("=============================");
                    Console.WriteLine("Employee Management System");
                    Console.WriteLine("=============================");
                    Console.WriteLine("1. Add Employee\r\n2. Update Employee\r\n3. Delete Employee\r\n4. Display Employees\r\n5. Exit\r\n");
                    n = Convert.ToInt32(Console.ReadLine());

                    switch (n)
                    {
                        case 1:
                            Console.WriteLine("Enter Employee Details:");

                            string name;
                            do
                            {
                                Console.Write("Enter Name: ");
                                name = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(name))
                                {
                                    Console.WriteLine("Error: Name cannot be empty or null. Please enter again.");
                                }
                            } while (string.IsNullOrWhiteSpace(name));

                            string department;
                            do
                            {
                                Console.Write("Enter Department: ");
                                department = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(department))
                                {
                                    Console.WriteLine("Error: Department cannot be empty or null. Please enter again.");
                                }
                            } while (string.IsNullOrWhiteSpace(department));

                            int age;
                            do
                            {
                                Console.Write("Enter Age: ");
                                if (!int.TryParse(Console.ReadLine(), out age) || age < 18 || age > 65)
                                {
                                    Console.WriteLine("Error: Age must be between 18 and 65. Please enter again.");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            decimal salary;
                            do
                            {
                                Console.Write("Enter Salary: ");
                                if (!decimal.TryParse(Console.ReadLine(), out salary) || salary <= 0)
                                {
                                    Console.WriteLine("Error: Salary should be a positive decimal value. Please enter again.");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            EmployeeFunctionalities.AddEmployee(name, department, age, salary);
                            break;
                        case 2:
                            Console.Write("Enter the ID of the employee you want to update: ");
                            int uId = Convert.ToInt32(Console.ReadLine());

                            string uName;
                            do
                            {
                                Console.Write("Enter the new Name: ");
                                uName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(uName))
                                {
                                    Console.WriteLine("Error: Name cannot be empty or null. Please enter again.");
                                }
                            } while (string.IsNullOrWhiteSpace(uName));

                            string uDepartment;
                            do
                            {
                                Console.Write("Enter the new Department: ");
                                uDepartment = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(uDepartment))
                                {
                                    Console.WriteLine("Error: Department cannot be empty or null. Please enter again.");
                                }
                            } while (string.IsNullOrWhiteSpace(uDepartment));

                            int uAge;
                            do
                            {
                                Console.Write("Enter the new Age: ");
                                if (!int.TryParse(Console.ReadLine(), out uAge) || uAge < 18 || uAge > 65)
                                {
                                    Console.WriteLine("Error: Age must be between 18 and 65. Please enter again.");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            decimal uSalary;
                            do
                            {
                                Console.Write("Enter the new Salary: ");
                                if (!decimal.TryParse(Console.ReadLine(), out uSalary) || uSalary <= 0)
                                {
                                    Console.WriteLine("Error: Salary should be a positive decimal value. Please enter again.");
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            EmployeeFunctionalities.UpdateEmployee(uId, uName, uDepartment, uAge, uSalary);
                            break;

                        case 3:
                            Console.Write("Enter the ID of the employee you want to delete: ");
                            int dId = Convert.ToInt32(Console.ReadLine());
                            EmployeeFunctionalities.DeleteEmployee(dId);
                            break;
                        case 4:
                            EmployeeFunctionalities.DisplayEmployees();
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("enter valid option");
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
    }
}
