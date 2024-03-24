using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PropertyManageSystem.Models;

public partial class WInstallation
{
    public int Id { get; set; }

    public int SpId { get; set; }

    [DisplayName("设施联系人")]
    public string? Name { get; set; }

    [DisplayName("联系电话")]
    public string? Phone { get; set; }

    [DisplayName("负责人")]
    public string? MainName { get; set; }

    [DisplayName("设施介绍")]
    public string? Contents { get; set; }

    [DisplayName("设施标题")]
    public string? Title { get; set; }

    public virtual WSystemParam Sp { get; set; } = null!;
}
