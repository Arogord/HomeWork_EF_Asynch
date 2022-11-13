using HomeWorCore_MVC_DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_EF_Asynch.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Sensors> sensors { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CourseDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}