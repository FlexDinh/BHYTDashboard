using System;
using System.Collections.Generic;

namespace BHYTDashboard.Models.Entities;

public partial class DanhMucIcd10
{
    public string MaIcd { get; set; } = null!;

    public string TenBenh { get; set; } = null!;

    public virtual ICollection<HoSoBenhNhan> HoSoBenhNhans { get; set; } = new List<HoSoBenhNhan>();
}
