using System;
using System.Collections.Generic;

namespace BHYTDashboard.Models.Entities;

public partial class DanhMucDoiTuong
{
    public string MaDoiTuong { get; set; } = null!;

    public string TenDoiTuong { get; set; } = null!;

    public virtual ICollection<HoSoBenhNhan> HoSoBenhNhans { get; set; } = new List<HoSoBenhNhan>();
}
