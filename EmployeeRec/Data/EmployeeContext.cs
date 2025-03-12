using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRec.models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeRec.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HARSHITGUNDA;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
