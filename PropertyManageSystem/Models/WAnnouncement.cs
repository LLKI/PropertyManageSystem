using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PropertyManageSystem.Models;

public partial class WAnnouncement
{
    public int Id { get; set; }

    [DisplayName("公告编号")]
    public string? Number { get; set; }
    [DisplayName("公告标题")]
    public string? Title { get; set; }
    [DisplayName("创建时间")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? Createtime { get; set; }
    [DisplayName("公告内容")]
    public string? Contents { get; set; }

    public int? Uid { get; set; }
    [DisplayName("昵称")]
    public string? Nickname { get; set; }

    public virtual WAdmin? UidNavigation { get; set; }
}
