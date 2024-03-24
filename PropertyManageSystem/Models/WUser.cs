using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PropertyManageSystem.Models;

public partial class WUser
{
    public int Id { get; set; }

    public int? BuildingId { get; set; }

    public int? DanyuanId { get; set; }

    public int? HouseId { get; set; }
    [DisplayName("业主名字")]
    public string UserName { get; set; } = null!;
    [DisplayName("房产证号")]
    public string HouseNumber { get; set; } = null!;
    [DisplayName("联系电话")]
    public string Phone { get; set; } = null!;
    [DisplayName("邮箱")]
    public string Email { get; set; } = null!;
    [DisplayName("身份证号码")]
    public string IdNumber { get; set; } = null!;
    [DisplayName("工作地址")]
    public string WorkAddress { get; set; } = null!;
    [DisplayName("联系地址")]
    public string LinkAddress { get; set; } = null!;
    [DisplayName("用户名")]
    public string Username1 { get; set; } = null!;
    [DisplayName("密码")]
    public string Password { get; set; } = null!;
    [DisplayName("备注")]
    public string? Remark { get; set; }
    [DisplayName("添加时间")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? Createtime { get; set; }

    public virtual WBuilding? Building { get; set; }

    public virtual WSystemParam? Danyuan { get; set; }

    public virtual WHouse? House { get; set; }

    public virtual ICollection<WPacking> WPackings { get; set; } = new List<WPacking>();

    public virtual ICollection<WRepair> WRepairs { get; set; } = new List<WRepair>();
}
