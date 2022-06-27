using System.ComponentModel.DataAnnotations;

namespace AbsenceRequests.Models;

public class AbsenceType
{
    [Key]
    public int AbsenceTypeID { get; set; }

    [MaxLength(50)]
    public string Title { get; set; } = default!;
}