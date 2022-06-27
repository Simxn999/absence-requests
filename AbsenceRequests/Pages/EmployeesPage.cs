using AbsenceRequests.Data;
using AbsenceRequests.Navigation;

namespace AbsenceRequests.Pages;

public class EmployeesPage : Page
{
    readonly DataContext _context;

    public EmployeesPage(DataContext context)
    {
        _context = context;
        Title = "Employees";
    }

    protected override void UpdateOptions()
    {
        Options.Clear();

        foreach (var employee in _context.Employees.ToList())
            Options.Add($"{employee.Name} {employee.Surname}", () => { new EmployeePage(_context, employee.EmployeeID).Run(); });
    }
}