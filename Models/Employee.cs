using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? CardId { get; set; }

    public string? EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Gender { get; set; }

    public DateTime Dateofbirth { get; set; }

    public int? Age { get; set; }
}
