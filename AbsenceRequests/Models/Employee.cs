using System.ComponentModel.DataAnnotations;

namespace AbsenceRequests.Models;

public class Employee
{
    [Key]
    public int EmployeeID { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [MaxLength(50)]
    public string Surname { get; set; } = default!;

    [MaxLength(100)]
    public string Email { get; set; } = default!;

    [MaxLength(16)]
    public string PhoneNumber { get; set; } = default!;

    public ICollection<AbsenceRequest> AbsenceRequests { get; set; } = new List<AbsenceRequest>();
}