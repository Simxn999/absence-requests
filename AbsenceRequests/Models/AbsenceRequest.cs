using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbsenceRequests.Models;

public class AbsenceRequest
{
    [Key]
    public int AbsenceRequestID { get; set; }

    public int EmployeeID { get; set; }
    public Employee? Employee { get; set; }
    public int AbsenceTypeID { get; set; }
    public AbsenceType? AbsenceType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [NotMapped]
    public string Duration
    {
        get
        {
            var days = EndDate.Subtract(StartDate).Days + 1;

            return days switch
                   {
                       1 => $"{days} day",
                       _ => $"{days} days",
                   };
        }
    }
}