using AbsenceRequests.Data;
using AbsenceRequests.Models;
using AbsenceRequests.Navigation;
using Microsoft.EntityFrameworkCore;

namespace AbsenceRequests.Pages;

public class HomePage : Page
{
    readonly DataContext _context;
    int? _userId;

    public HomePage()
    {
        Console.Title = "Absence Requests";
        Console.WriteLine("Loading...");

        _context = new DataContext();
        _context.Employees.Load();
        _context.AbsenceTypes.Load();
        _context.AbsenceRequests.Load();

        Title = "Absence Requests";
    }

    protected override void UpdateOptions()
    {
        Options.Clear();
        switch (_userId)
        {
            case null:
                Options.Add("Absence Requests", OptionRequests);
                Options.Add("Employees", OptionEmployees);
                Options.Add("Login", LogIn);
                return;

            case > 0:
                Options.Add("My Profile", OptionProfile);
                Options.Add("Request Absence", OptionRequest);
                Options.Add("Logout", LogOut);
                return;

            default:
                return;
        }
    }

    void LogIn()
    {
        var inputPage = new LoginPage(_context);
        inputPage.Run();

        if (inputPage.ReturnValue is not Employee employee) return;

        _userId = employee.EmployeeID;
        Title = $"Absence Requests: Logged in as {employee.Name} {employee.Surname}";
    }

    void LogOut()
    {
        _userId = null;
        Title = "Absence Requests";
    }

    void OptionProfile()
    {
        if (_userId is null) return;

        new EmployeePage(_context, _userId).Run();
    }

    void OptionRequest()
    {
        if (_userId is null) return;

        new RequestPage(_context, (int)_userId).Run();
    }

    void OptionRequests()
    {
        new ViewRequestsPage(_context).Run();
    }

    void OptionEmployees()
    {
        new EmployeesPage(_context).Run();
    }
}