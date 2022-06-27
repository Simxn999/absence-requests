using AbsenceRequests.Data;
using AbsenceRequests.Navigation;

namespace AbsenceRequests.Pages;

public class LoginPage : Page
{
    readonly DataContext _context;

    public LoginPage(DataContext context)
    {
        Title = "Login";
        _context = context;
    }

    protected override void UpdateOptions()
    {
        Options.Clear();

        foreach (var employee in _context.Employees.ToList())
            Options.Add($"{employee.Name} {employee.Surname}",
                        () =>
                        {
                            ReturnValue = employee.EmployeeID;
                            Exit = true;
                        });
    }
}