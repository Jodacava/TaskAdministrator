using System;
using System.Collections.Generic;

namespace TaskAdministrator.Models;

public partial class Status
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string Name { get; set; } = null!;
}
