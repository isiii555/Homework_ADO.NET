using System;
using System.Collections.Generic;

namespace AdoFirst.Models;

public partial class StudentTeacherLib
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
