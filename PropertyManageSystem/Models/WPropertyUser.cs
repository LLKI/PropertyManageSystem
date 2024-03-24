using System;
using System.Collections.Generic;

namespace PropertyManageSystem.Models;

public partial class WPropertyUser
{
    public int Id { get; set; }

    public string WyNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Sex { get; set; }

    public string WorkName { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Pic { get; set; } = null!;

    public string WorkInfo { get; set; } = null!;
}
