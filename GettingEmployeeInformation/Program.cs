using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models;
using GettingEmployeeInformation.Models.DTOs;
using GettingEmployeeInformation.Services;
using Microsoft.EntityFrameworkCore;

namespace GettingEmployeeInformation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register your DbContext
            builder.Services.AddDbContext<EmpContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

            // Register your repositories
            builder.Services.AddScoped<IRepo<EmployeeDetails>, EmployeeDetailsRepo>();
            builder.Services.AddScoped<IRepo<ExperienceLevel>, ExpereniceLevelRepo>();
            builder.Services.AddScoped<IRepo<Vacation>, VacationRepo>();
            //registering the services
            builder.Services.AddScoped<IServiceRepo<EmployeeInformationDTO>, EmployeeDetailsService>();
            builder.Services.AddScoped<IServiceRepo<EmployeeInformationDTO>, ExpereniceLevelService>();
            builder.Services.AddScoped<IServiceRepo<EmployeeInformationDTO>,VacationService>();
            builder.Services.AddScoped<IServiceRepo<EmployeeInformationDTO>,ExpereniceLevelLeadershipService>();



            var app = builder.Build();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1");
                c.RoutePrefix = string.Empty; // Serve the Swagger UI at the root URL
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
