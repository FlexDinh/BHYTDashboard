using System;
using System.Collections.Generic;

namespace BHYTDashboard.Models.Entities;

public partial class DanhMucNhomChiPhi
{
    public string MaNhomChiPhi { get; set; } = null!;

    public string TenNhomChiPhi { get; set; } = null!;

    public virtual ICollection<ChiTietDvkt> ChiTietDvkts { get; set; } = new List<ChiTietDvkt>();

    public virtual ICollection<ChiTietThuoc> ChiTietThuocs { get; set; } = new List<ChiTietThuoc>();
}
