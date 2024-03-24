using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PropertyManageSystem.Models;

public partial class WUserPaymoney
{
    public int Id { get; set; }
    [DisplayName("住户房间")]
    public int? HouseId { get; set; }
    [DisplayName("数量")]
    public int? Number { get; set; }
    [DisplayName("价格")]
    public decimal? Price { get; set; }
    [DisplayName("应付金额")]
    public decimal? ShouldPay { get; set; }
    [DisplayName("实付金额")]
    public decimal? RealyPay { get; set; }
    [DisplayName("未支付金额")]
    public decimal? NoPay { get; set; }
    [DisplayName("收费开始时间")]
    public DateTime? StartPayTime { get; set; }

    public int? ById { get; set; }
    [DisplayName("收费标题")]
    public string? Title { get; set; }
    [DisplayName("经手人")]
    public virtual WAdmin? By { get; set; }

    public virtual WHouse? House { get; set; }
}
