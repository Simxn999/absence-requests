using AbsenceRequests.Models;
using Microsoft.EntityFrameworkCore;

namespace AbsenceRequests.Data;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<AbsenceRequest> AbsenceRequests => Set<AbsenceRequest>();
    public DbSet<AbsenceType> AbsenceTypes => Set<AbsenceType>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = SIMXN\\SQLEXPRESS; Initial Catalog = AbsenceRequests; Integrated Security = True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Employees

        modelBuilder.Entity<Employee>()
                    .HasData(new Employee
                    {
                        EmployeeID = 1,
                        Name = "Simon",
                        Surname = "Johansson",
                        Email = "simon.johansson@mail.com",
                        PhoneNumber = "123 456 78 91",
                    });
        modelBuilder.Entity<Employee>()
                    .HasData(new Employee
                    {
                        EmployeeID = 2,
                        Name = "Elon",
                        Surname = "Musk",
                        Email = "elon.musk@mail.com",
                        PhoneNumber = "123 456 78 92",
                    });
        modelBuilder.Entity<Employee>()
                    .HasData(new Employee
                    {
                        EmployeeID = 3,
                        Name = "Jeff",
                        Surname = "Bezos",
                        Email = "jeff.bezos@mail.com",
                        PhoneNumber = "123 456 78 93",
                    });
        modelBuilder.Entity<Employee>()
                    .HasData(new Employee
                    {
                        EmployeeID = 4,
                        Name = "Steve",
                        Surname = "Jobs",
                        Email = "steve.jobs@mail.com",
                        PhoneNumber = "123 456 78 94",
                    });

        // AbsenceTypes

        modelBuilder.Entity<AbsenceType>()
                    .HasData(new AbsenceType
                    {
                        AbsenceTypeID = 1,
                        Title = "Vacation",
                    });
        modelBuilder.Entity<AbsenceType>()
                    .HasData(new AbsenceType
                    {
                        AbsenceTypeID = 2,
                        Title = "Family",
                    });
        modelBuilder.Entity<AbsenceType>()
                    .HasData(new AbsenceType
                    {
                        AbsenceTypeID = 3,
                        Title = "Medical",
                    });
        modelBuilder.Entity<AbsenceType>()
                    .HasData(new AbsenceType
                    {
                        AbsenceTypeID = 4,
                        Title = "Personal",
                    });
        modelBuilder.Entity<AbsenceType>()
                    .HasData(new AbsenceType
                    {
                        AbsenceTypeID = 5,
                        Title = "Military",
                    });

        // AbsenceRequests

        modelBuilder.Entity<AbsenceRequest>()
                    .HasData(new AbsenceRequest
                    {
                        AbsenceRequestID = 1,
                        EmployeeID = 1,
                        AbsenceTypeID = 1,
                        StartDate = new DateTime(2022, 6, 30),
                        EndDate = new DateTime(2022, 7, 6),
                    });
    }
}