using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PropertyManageSystem.Models;

public partial class WDevice
{
    public int Id { get; set; }
    [DisplayName("物品编号")]
    public long? DeviceId { get; set; }
    [DisplayName("物品名称")]
    public string? DeviceName { get; set; }
    [DisplayName("物品描述")]
    public string? DeviceDesc { get; set; }
    [DisplayName("创建时间")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? Createtime { get; set; }
}
