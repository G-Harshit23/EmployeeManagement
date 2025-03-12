using Microsoft.EntityFrameworkCore;
using EmployeeRec.Data;
using EmployeeRec.models;
namespace EmployeeRec
{
    internal class EmployeeFunctionalities
    {
        private readonly EmployeeContext _context;

        public EmployeeFunctionalities(EmployeeContext context)
        {
            _context = context;
        }
        private int flag = 1;
        public void AddEmployee(string name, string department, int age, decimal salary)
        {
            Employee employee = new Employee();
            employee.Name = name;
            employee.Department = department;
            employee.age = age;
            employee.Salary = salary;
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return;
        }
        public void UpdateEmployee(int id, string name, string department, int age, decimal salary)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                employee.Name = name;
                employee.Department = department;
                employee.age = age;
                employee.Salary = salary;
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Employee Record Not Found");
            }
        }
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Employee Record Not Found");
            }
        }
        public void DisplayEmployees()
        {
            var employees = _context.Employees.AsNoTracking().ToList();
            if (employees.Count == 0)
            {
                Console.WriteLine("No Employee Record Found");
            }
            else
            {
                foreach (var emp in employees)
                {
                    Console.WriteLine("Employee ID: " + emp.Id);
                    Console.WriteLine("Employee Name: " + emp.Name);
                    Console.WriteLine("Employee Department: " + emp.Department);
                    Console.WriteLine("Employee Age: " + emp.age);
                    Console.WriteLine("Employee Salary: " + emp.Salary.ToString("C"));
                    Console.WriteLine("=============================");
                }
            }
        }
    }
}
