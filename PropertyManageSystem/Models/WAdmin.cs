using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyManageSystem.Models;

public partial class WAdmin
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? Pass { get; set; }

    public string? NickName { get; set; }

    public int? Power { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? CreateTime { get; set; }

    public virtual ICollection<WAnnouncement> WAnnouncements { get; set; } = new List<WAnnouncement>();

    public virtual ICollection<WUserPaymoney> WUserPaymoneys { get; set; } = new List<WUserPaymoney>();
}
