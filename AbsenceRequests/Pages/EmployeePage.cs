using AbsenceRequests.Data;
using AbsenceRequests.Navigation;

namespace AbsenceRequests.Pages;

public class EmployeePage : Page
{
    readonly DataContext _context;

    public EmployeePage(DataContext context, int? employeeID)
    {
        _context = context;

        Title = "Employee Profile";
        Content = () => EmployeeContent(employeeID);
    }

    void EmployeeContent(int? employeeID)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
        if (employee is null)
        {
            Exit = true;
            return;
        }

        Console.Write("Name:");
        Console.CursorLeft = 20;
        Console.WriteLine($"{employee.Name} {employee.Surname}");

        Console.Write("ID:");
        Console.CursorLeft = 20;
        Console.WriteLine($"{employee.EmployeeID}");

        Console.Write("Email:");
        Console.CursorLeft = 20;
        Console.WriteLine($"{employee.Email}");

        Console.Write("Phone number:");
        Console.CursorLeft = 20;
        Console.WriteLine($"{employee.PhoneNumber}");

        Console.Write("Absence Requests:");
        Console.CursorLeft = 20;
        Console.WriteLine($"{employee.AbsenceRequests.Count}");
        if (!employee.AbsenceRequests.Any()) return;

        Console.CursorTop++;

        foreach (var request in employee.AbsenceRequests)
        {
            Console.CursorLeft = 2;
            Console.WriteLine(request.Duration);

            Console.CursorLeft = 4;
            Console.WriteLine($"{request.StartDate.ToShortDateString()} - {request.EndDate.ToShortDateString()}");

            Console.CursorTop++;
        }
    }
}