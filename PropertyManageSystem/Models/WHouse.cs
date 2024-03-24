using System;
using System.Collections.Generic;

namespace PropertyManageSystem.Models;

public partial class WHouse
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int BId { get; set; }

    public int DId { get; set; }

    public int? DRoom { get; set; }

    public int CId { get; set; }

    public int? RId { get; set; }

    public int? GId { get; set; }

    public int? BzId { get; set; }

    public decimal? Area { get; set; }

    public decimal? UseArea { get; set; }

    public int? IsUse { get; set; }

    public virtual WBuilding BIdNavigation { get; set; } = null!;

    public virtual WSystemParam? Bz { get; set; }

    public virtual WSystemParam CIdNavigation { get; set; } = null!;

    public virtual WSystemParam DIdNavigation { get; set; } = null!;

    public virtual WSystemParam? DRoomNavigation { get; set; }

    public virtual WSystemParam? GIdNavigation { get; set; }

    public virtual WSystemParam? RIdNavigation { get; set; }

    public virtual ICollection<WComplaint> WComplaints { get; set; } = new List<WComplaint>();

    public virtual ICollection<WRepair> WRepairs { get; set; } = new List<WRepair>();

    public virtual ICollection<WUserPaymoney> WUserPaymoneys { get; set; } = new List<WUserPaymoney>();

    public virtual ICollection<WUser> WUsers { get; set; } = new List<WUser>();
}
