using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PropertyManageSystem.Models;

public partial class WRepair
{
    public int Id { get; set; }

    [DisplayName("报修标题")]
    public string? Title { get; set; }
    [DisplayName("单元名称")]
    public string? UnitName { get; set; }

    public int? Uid { get; set; }
    [DisplayName("报修描述")]
    public string? Describe { get; set; }
    [DisplayName("报修状态")]
    public int? State { get; set; }
    [DisplayName("报修时间")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? Createtime { get; set; }
    [DisplayName("验收意见")]
    public string? RepeatInfo { get; set; }
    [DisplayName("报修审核")]
    public int? StateType { get; set; }

    public int? LouyuId { get; set; }

    public int? DanyuanId { get; set; }
    [DisplayName("维修编号")]
    public string? RepairNumber { get; set; }

    public int? HouseId { get; set; }
    [DisplayName("最后处理人")]
    public string? FinalyRepairUser { get; set; }
    [DisplayName("维修单位")]
    public string? RepairWorkInfo { get; set; }
    [DisplayName("主要负责人")]
    public string? MainRepairUser { get; set; }
    [DisplayName("联系电话")]
    public string? RepairPhone { get; set; }
    
    public int? RepairPass { get; set; }
    [DisplayName("审核说明")]
    public string? PassDetail { get; set; }

    public string? RepairInfo { get; set; }

    public virtual WSystemParam? Danyuan { get; set; }

    public virtual WHouse? House { get; set; }

    public virtual WBuilding? Louyu { get; set; }

    public virtual WUser? UidNavigation { get; set; }
}
