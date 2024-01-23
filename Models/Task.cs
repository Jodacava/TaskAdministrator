using System;
using System.Collections.Generic;

namespace TaskAdministrator.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }
}
