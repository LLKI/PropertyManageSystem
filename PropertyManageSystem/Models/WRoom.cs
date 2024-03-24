using System;
using System.Collections.Generic;

namespace PropertyManageSystem.Models;

public partial class WRoom
{
    public int Id { get; set; }

    public string? RoomId { get; set; }

    public string? Floor { get; set; }

    public string? Owner { get; set; }

    public string? Phone { get; set; }

    public string? Type { get; set; }

    public string? ConstructionArea { get; set; }

    public string? ActualArea { get; set; }

    public string? HomeState { get; set; }
}
