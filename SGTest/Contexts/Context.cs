using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGTest.Constants;
using SGTest.Models.DatabaseModels;

namespace SGTest.Contexts
{
    /// <summary>
    /// Класс контекста для orm - Entity Framework
    /// </summary>
    public class Context : DbContext
    {

        public Context() : base() 
        {
            Database.EnsureCreated();
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<JobTitle> JobTitles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .Build();
           
            optionsBuilder.UseNpgsql(config.GetConnectionString(ConnectionsNames.POSTGRES_CONNECTION));
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Error);
        }
    }
}
