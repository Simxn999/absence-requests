using AbsenceRequests.Navigation;

namespace AbsenceRequests.Pages;

public class FilterPage : Page
{
    public FilterPage(DateTime currentDate, string type)
    {
        ReturnValue = currentDate;
        Title = $"Filter {type} Date - Current: [{currentDate.ToShortDateString()}]";

        Content = RequestDate;
    }

    void RequestDate()
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
                    Console.WriteLine("Invalid input! Press any key...");
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