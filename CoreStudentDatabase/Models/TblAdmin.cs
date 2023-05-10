using System;
using System.Collections.Generic;

namespace CoreStudentDatabase.Models;

public partial class TblAdmin
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime DateCreated { get; set; }
}
