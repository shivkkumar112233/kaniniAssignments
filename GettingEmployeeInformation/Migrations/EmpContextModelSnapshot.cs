﻿// <auto-generated />
using GettingEmployeeInformation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GettingEmployeeInformation.Migrations
{
    [DbContext(typeof(EmpContext))]
    partial class EmpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GettingEmployeeInformation.Models.EmployeeDetails", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"), 1L, 1);

                    b.Property<string>("ActiveStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BillableId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmplName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocId")
                        .HasColumnType("int");

                    b.Property<int>("PraticeId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.ToTable("EmployeeDetailss");

                    b.HasData(
                        new
                        {
                            EmpId = 1,
                            ActiveStatus = "Active",
                            BillableId = 1,
                            Email = "malinivelu.kanini@gmail.com",
                            EmplName = "Malini",
                            LocId = 1,
                            PraticeId = 1,
                            ResourceId = 1
                        },
                        new
                        {
                            EmpId = 2,
                            ActiveStatus = "Active",
                            BillableId = 2,
                            Email = "maha.kanini@gmail.com",
                            EmplName = "Maha",
                            LocId = 2,
                            PraticeId = 2,
                            ResourceId = 2
                        },
                        new
                        {
                            EmpId = 3,
                            ActiveStatus = "Relieved",
                            BillableId = 3,
                            Email = "nithya.kanini@gmail.com",
                            EmplName = "Nithya",
                            LocId = 3,
                            PraticeId = 3,
                            ResourceId = 3
                        },
                        new
                        {
                            EmpId = 4,
                            ActiveStatus = "Relieved",
                            BillableId = 4,
                            Email = "sangamithra.kanini@gmail.com",
                            EmplName = "Sangamithra",
                            LocId = 4,
                            PraticeId = 4,
                            ResourceId = 4
                        },
                        new
                        {
                            EmpId = 5,
                            ActiveStatus = "Active",
                            BillableId = 5,
                            Email = "siva.kanini@gmail.com",
                            EmplName = "Siva",
                            LocId = 5,
                            PraticeId = 5,
                            ResourceId = 5
                        });
                });

            modelBuilder.Entity("GettingEmployeeInformation.Models.ExperienceLevel", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmpId1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"), 1L, 1);

                    b.Property<string>("EmployeesLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmpId");

                    b.Property<int>("SkillScore")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.ToTable("ExperienceLevels");

                    b.HasData(
                        new
                        {
                            EmpId = 1,
                            EmployeesLevel = "JuniorLevel",
                            SkillScore = 50
                        },
                        new
                        {
                            EmpId = 2,
                            EmployeesLevel = "MidLevel",
                            SkillScore = 52
                        },
                        new
                        {
                            EmpId = 3,
                            EmployeesLevel = "SeniorLevel",
                            SkillScore = 54
                        },
                        new
                        {
                            EmpId = 4,
                            EmployeesLevel = "JuniorLevel",
                            SkillScore = 51
                        },
                        new
                        {
                            EmpId = 5,
                            EmployeesLevel = "JuniorLevel",
                            SkillScore = 53
                        });
                });

            modelBuilder.Entity("GettingEmployeeInformation.Models.Vacation", b =>
                {
                    b.Property<int>("VacationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacationId"), 1L, 1);

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.HasKey("VacationId");

                    b.ToTable("Vacations");

                    b.HasData(
                        new
                        {
                            VacationId = 101,
                            EmpId = 1
                        },
                        new
                        {
                            VacationId = 102,
                            EmpId = 2
                        },
                        new
                        {
                            VacationId = 105,
                            EmpId = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
