using System;
using System.Collections.Generic;

namespace PropertyManageSystem.Models;

public partial class WRoomInfo
{
    public int Id { get; set; }

    public string CommunityName { get; set; } = null!;

    public string ManagerPhone { get; set; } = null!;

    public string? ManagerName { get; set; }

    public double? ParkLotArea { get; set; }

    public DateTime? ConstructDate { get; set; }

    public double? RoadArea { get; set; }

    public double? RoomArea { get; set; }

    public double? GreenArea { get; set; }

    public int? RoomCount { get; set; }

    public string CommunityAddress { get; set; } = null!;

    public string? CommunityRemark { get; set; }
}
