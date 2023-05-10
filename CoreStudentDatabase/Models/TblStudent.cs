using System;
using System.Collections.Generic;

namespace CoreStudentDatabase.Models;

public partial class TblStudent
{
    public int Id { get; set; }

    public string StudentNumber { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string StudentAddress { get; set; } = null!;

    public int StudentYearLevel { get; set; }

    public string StudentContactNumber { get; set; } = null!;

    public bool Status { get; set; }
}
