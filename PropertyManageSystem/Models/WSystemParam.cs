using System;
using System.Collections.Generic;

namespace PropertyManageSystem.Models;

public partial class WSystemParam
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<WBuilding> WBuildings { get; set; } = new List<WBuilding>();

    public virtual ICollection<WHouse> WHouseBzs { get; set; } = new List<WHouse>();

    public virtual ICollection<WHouse> WHouseCIdNavigations { get; set; } = new List<WHouse>();

    public virtual ICollection<WHouse> WHouseDIdNavigations { get; set; } = new List<WHouse>();

    public virtual ICollection<WHouse> WHouseDRoomNavigations { get; set; } = new List<WHouse>();

    public virtual ICollection<WHouse> WHouseGIdNavigations { get; set; } = new List<WHouse>();

    public virtual ICollection<WHouse> WHouseRIdNavigations { get; set; } = new List<WHouse>();

    public virtual ICollection<WInstallation> WInstallations { get; set; } = new List<WInstallation>();

    public virtual ICollection<WRepair> WRepairs { get; set; } = new List<WRepair>();

    public virtual ICollection<WUser> WUsers { get; set; } = new List<WUser>();
}
