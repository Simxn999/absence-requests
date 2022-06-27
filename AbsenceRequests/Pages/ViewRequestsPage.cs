using AbsenceRequests.Data;
using AbsenceRequests.Navigation;

namespace AbsenceRequests.Pages;

public class ViewRequestsPage : Page
{
    readonly DataContext _context;
    DateTime _endDate;
    DateTime _startDate;

    public ViewRequestsPage(DataContext context)
    {
        _context = context;
        _startDate = context.AbsenceRequests.OrderBy(r => r.StartDate).Select(r => r.StartDate).FirstOrDefault();
        _endDate = context.AbsenceRequests.OrderBy(r => r.EndDate).Select(r => r.EndDate).LastOrDefault();

        Title = "Registered Absence Requests";

        Content = RequestsContent;
    }

    protected override void UpdateOptions()
    {
        Options.Clear();
        Options.Add("Filter Start Date", OptionFilterStart);
        Options.Add("Filter End Date", OptionFilterEnd);
    }

    void OptionFilterStart()
    {
        var inputPage = new FilterPage(_startDate, "Start");
        inputPage.Run();

        if (inputPage.ReturnValue is DateTime date)
            _startDate = date;
    }

    void OptionFilterEnd()
    {
        var inputPage = new FilterPage(_endDate, "End");
        inputPage.Run();

        if (inputPage.ReturnValue is DateTime date)
            _endDate = date;
    }

    void RequestsContent()
    {
        var employees = _context.Employees.ToList();
        var requests = _context.AbsenceRequests.Where(r => r.StartDate >= _startDate && r.EndDate <= _endDate).ToList();

        Console.WriteLine($"{requests.Count} Requests between {_startDate.ToShortDateString()} and {_endDate.ToShortDateString()}");
        Console.CursorTop += 1;
        foreach (var employee in employees)
        {
            var employeeRequests = requests.Where(r => employee.EmployeeID == r.EmployeeID).ToList();
            if (!employeeRequests.Any()) continue;

            Console.CursorLeft = 2;
            Console.WriteLine($"{employee.Name} {employee.Surname}");
            foreach (var request in employeeRequests)
            {
                Console.CursorLeft = 4;
                Console.WriteLine($"{request.Duration} between {request.StartDate.ToShortDateString()} and {request.EndDate.ToShortDateString()}");
            }

            Console.CursorTop += 1;
        }
    }
}