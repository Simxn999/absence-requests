using AbsenceRequests.Data;
using AbsenceRequests.Models;
using AbsenceRequests.Navigation;

namespace AbsenceRequests.Pages;

public class RequestInputPage : Page
{
    readonly DataContext _context;
    readonly string _property;
    readonly AbsenceRequest _request;

    public RequestInputPage(DataContext context, string property, AbsenceRequest request)
    {
        _context = context;
        _property = property;
        _request = request;
        List<string> validTypes = new() { "type", "start", "end", };

        if (!validTypes.Contains(property)) return;

        Options.Clear();

        switch (_property)
        {
            case "type":
                Title =
                    $"Select Type of Absence - Current: [{_context.AbsenceTypes.FirstOrDefault(t => t.AbsenceTypeID == _request.AbsenceTypeID)?.Title ?? "UNDEFINED"}]";
                OptionTypeInput();
                break;

            case "start":
                Title = $"Enter Start Date - Current: [{_request.StartDate.ToShortDateString()}]";
                OptionDateInput();
                break;

            case "end":
                Title = $"Enter End Date - Current: [{_request.EndDate.ToShortDateString()}]";
                OptionDateInput();
                break;
        }
    }

    void OptionTypeInput()
    {
        foreach (var type in _context.AbsenceTypes.ToList())
            Options.Add(type.Title,
                        () =>
                        {
                            ReturnValue = type;
                            Exit = true;
                        });
    }

    void OptionDateInput()
    {
        Options.Add("#enter#Confirm", () => { });

        while (true)
        {
            Content = () => { Console.Write("Date = "); };
            Print();
            var input = Console.ReadLine();

            if (input is null || !input.Trim().Any())
            {
                Exit = true;
                return;
            }

            if (!DateTime.TryParse(input, out var date))
            {
                Content = () =>
                {
                    Console.WriteLine("Invalid input! Press any key to continue...");
                    Console.ReadKey(true);
                };
                Print();
                continue;
            }

            ReturnValue = date;
            Exit = true;
            break;
        }
    }
}