using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PropertyManageSystem.Models;

public partial class WBuilding
{
    public int Id { get; set; }

    [DisplayName("楼宇名称")]
    public string? RoomName { get; set; }
    [DisplayName("楼宇层数")]
    public int? Floors { get; set; }
    [DisplayName("楼宇高度")]
    public decimal? Height { get; set; }
    [DisplayName("楼宇面积")]
    public decimal? Area { get; set; }
    [DisplayName("创建时间")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? Createtime { get; set; }

    [DisplayName("楼宇类型")]
    public int? SpId { get; set; }

    [DisplayName("备注说明")]
    public string? Remark { get; set; }

    public virtual WSystemParam? Sp { get; set; }

    public virtual ICollection<WHouse> WHouses { get; set; } = new List<WHouse>();

    public virtual ICollection<WRepair> WRepairs { get; set; } = new List<WRepair>();

    public virtual ICollection<WUser> WUsers { get; set; } = new List<WUser>();
}
