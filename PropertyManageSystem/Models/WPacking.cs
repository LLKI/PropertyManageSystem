using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PropertyManageSystem.Models;

public partial class WPacking
{
    public int Id { get; set; }
    [DisplayName("停车场")]
    public string? PackingName { get; set; }
    [DisplayName("车位")]
    public string? PackingLot { get; set; }
    [DisplayName("车位编号")]
    public long? PackingLotId { get; set; }
    [DisplayName("车位状态")]
    public int? PackingState { get; set; }
    [DisplayName("车位类型")]
    public int? PackingType { get; set; }
    [DisplayName("面积")]
    public decimal? PackingArea { get; set; }
    public int? PackingUid { get; set; }

    public virtual WUser? Packin { get; set; }
}
