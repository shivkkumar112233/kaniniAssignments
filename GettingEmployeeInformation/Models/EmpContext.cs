using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GettingEmployeeInformation.Models
{
    public class EmpContext:DbContext
    {
        public EmpContext(DbContextOptions options):base(options) 
            {

            }

        public DbSet<EmployeeDetails> EmployeeDetailss { get; set; }

        public DbSet<ExperienceLevel> ExperienceLevels { get; set; }

        public DbSet<Vacation>   Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetails>().HasData
               (new EmployeeDetails { EmpId = 1, EmplName = "Malini", Email = "malinivelu.kanini@gmail.com", LocId = 1, PraticeId = 1, BillableId = 1, ResourceId = 1, ActiveStatus = "Active" },
               new EmployeeDetails { EmpId = 2, EmplName = "Maha", Email = "maha.kanini@gmail.com", LocId = 2, PraticeId = 2, BillableId = 2, ResourceId = 2, ActiveStatus = "Active" },
               new EmployeeDetails { EmpId = 3, EmplName = "Nithya", Email = "nithya.kanini@gmail.com", LocId = 3, PraticeId = 3, BillableId = 3, ResourceId = 3, ActiveStatus = "Relieved" },
               new EmployeeDetails { EmpId = 4, EmplName = "Sangamithra", Email = "sangamithra.kanini@gmail.com", LocId = 4, PraticeId = 4, BillableId = 4, ResourceId = 4, ActiveStatus = "Relieved" },
               new EmployeeDetails { EmpId = 5, EmplName = "Siva", Email = "siva.kanini@gmail.com", LocId = 5, PraticeId = 5, BillableId = 5, ResourceId = 5, ActiveStatus = "Active" });
            modelBuilder.Entity<ExperienceLevel>().HasData
                (new ExperienceLevel { EmpId = 1, EmployeesLevel = "JuniorLevel", SkillScore = '2' },
               new ExperienceLevel { EmpId = 2, EmployeesLevel = "MidLevel", SkillScore = '4' },
               new ExperienceLevel { EmpId = 3, EmployeesLevel = "SeniorLevel", SkillScore = '6' },
               new ExperienceLevel { EmpId = 4, EmployeesLevel = "JuniorLevel", SkillScore = '3' },
               new ExperienceLevel { EmpId = 5, EmployeesLevel = "JuniorLevel", SkillScore = '5' }
               );
            modelBuilder.Entity<Vacation>().HasData
               (new Vacation { VacationId = 101, EmpId = 1 },
               new Vacation { VacationId = 102, EmpId = 2 },
               new Vacation { VacationId = 105, EmpId = 5 });

        }
    }
}
