using System;
using System.Collections.Generic;

namespace AspCrud.Models;

public partial class StudentInfo
{
    internal int id;

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? Class { get; set; }

    public string? Gender { get; set; }
}
