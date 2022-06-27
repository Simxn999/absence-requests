using AbsenceRequests.Data;
using AbsenceRequests.Models;
using AbsenceRequests.Navigation;

namespace AbsenceRequests.Pages;

public class RequestPage : Page
{
    readonly DataContext _context;
    readonly AbsenceRequest _request;

    public RequestPage(DataContext context, int employeeID)
    {
        _context = context;
        _request = new AbsenceRequest();

        var employee = _context.Employees.FirstOrDefault(employee => employee.EmployeeID == employeeID);

        if (employee is null) return;

        Title = $"Request Absence for {employee.Name} {employee.Surname}";

        _request.EmployeeID = employee.EmployeeID;
        _request.AbsenceTypeID = _context.AbsenceTypes.FirstOrDefault()?.AbsenceTypeID ?? 1;
        _request.StartDate = DateTime.Now;
        _request.EndDate = DateTime.Now;

        Content = () =>
        {
            Console.Write("Absence type:");
            Console.CursorLeft = 20;
            Console.WriteLine(_context.AbsenceTypes.FirstOrDefault(t => t.AbsenceTypeID == _request.AbsenceTypeID)?.Title ?? "[UNDEFINED]");

            Console.Write("Start date:");
            Console.CursorLeft = 20;
            Console.WriteLine(_request.StartDate.ToShortDateString());

            Console.Write("End date:");
            Console.CursorLeft = 20;
            Console.WriteLine(_request.EndDate.ToShortDateString());

            Console.Write("Duration:");
            Console.CursorLeft = 20;
            Console.WriteLine(_request.Duration);
        };
    }

    protected override void UpdateOptions()
    {
        Options.Clear();
        Options.Add("Select Type of Absence", OptionAbsenceType);
        Options.Add("Select Start Date", OptionStartDate);
        Options.Add("Select End Date", OptionEndDate);
        Options.Add("#enter#Submit Request", OptionSubmit);
    }

    void OptionAbsenceType()
    {
        var inputPage = new RequestInputPage(_context, "type", _request);
        inputPage.Run();

        if (inputPage.ReturnValue is not AbsenceType type) return;

        _request.AbsenceTypeID = type.AbsenceTypeID;
    }

    void OptionStartDate()
    {
        var inputPage = new RequestInputPage(_context, "start", _request);
        inputPage.Run();

        if (inputPage.ReturnValue is not DateTime date)
            return;

        _request.StartDate = date;

        if (_request.EndDate.Subtract(_request.StartDate).Days < 1)
            _request.EndDate = _request.StartDate;
    }

    void OptionEndDate()
    {
        var inputPage = new RequestInputPage(_context, "end", _request);
        inputPage.Run();

        if (inputPage.ReturnValue is not DateTime date)
            return;

        _request.EndDate = date;

        if (_request.EndDate.Subtract(_request.StartDate).Days < 1)
            _request.StartDate = _request.EndDate;
    }

    void OptionSubmit()
    {
        try
        {
            _context.Add(new AbsenceRequest
            {
                EmployeeID = _request.EmployeeID,
                AbsenceTypeID = _request.AbsenceTypeID,
                StartDate = _request.StartDate,
                EndDate = _request.EndDate,
            });
            _context.SaveChanges();

            Console.WriteLine("Successfully requested absence! Press any key to continue...");
            Console.ReadKey(true);

            Exit = true;
            new EmployeePage(_context, _request.EmployeeID).Run();
        }
        catch
        {
            Console.WriteLine("Error! Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}