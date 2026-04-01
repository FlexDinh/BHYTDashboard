using System;
using System.Collections.Generic;

namespace BHYTDashboard.Models.Entities;

public partial class ChiTietThuoc
{
    public int Id { get; set; }

    public string MaLk { get; set; } = null!;

    public string? MaThuoc { get; set; }

    public string? TenThuoc { get; set; }

    public string? DonViTinh { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public int? ThanhTien { get; set; }

    public int? TyLeThanhToan { get; set; }

    public string? MaNhomChiPhi { get; set; }

    public string? MaKhoa { get; set; }

    public virtual HoSoBenhNhan MaLkNavigation { get; set; } = null!;

    public virtual DanhMucNhomChiPhi? MaNhomChiPhiNavigation { get; set; }
}
