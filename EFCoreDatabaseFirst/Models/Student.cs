using System;
using System.Collections.Generic;

namespace EFCoreDatabaseFirst.Models;

public partial class Student
{
    public int Studentid { get; set; }

    public string Studentname { get; set; } = null!;

    public int Studentage { get; set; }

    public decimal Studentmarks { get; set; }
}
