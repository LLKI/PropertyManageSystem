using System;
using System.Collections.Generic;

namespace PropertyManageSystem.Models;

public partial class WComplaint
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Uid { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Describe { get; set; }

    public string? State { get; set; }

    public DateTime? Createtime { get; set; }

    public string? Title { get; set; }

    public int? IsUse { get; set; }

    public string? Result { get; set; }

    public int? HouseId { get; set; }

    public string? PassDetail { get; set; }

    public virtual WHouse? House { get; set; }
}
