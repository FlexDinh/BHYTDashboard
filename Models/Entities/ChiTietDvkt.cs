using System;
using System.Collections.Generic;

namespace BHYTDashboard.Models.Entities;

public partial class ChiTietDvkt
{
    public int Id { get; set; }

    public string MaLk { get; set; } = null!;

    public string? MaDichVu { get; set; }

    public string? TenDichVu { get; set; }

    public string? MaVatTu { get; set; }

    public string? TenVatTu { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public int? ThanhTien { get; set; }

    public string? MaNhomChiPhi { get; set; }

    public string? MaKhoa { get; set; }

    public string? MaBacSi { get; set; }

    public int? NgayYlenh { get; set; }

    public int? NgayKetQua { get; set; }

    public virtual HoSoBenhNhan MaLkNavigation { get; set; } = null!;

    public virtual DanhMucNhomChiPhi? MaNhomChiPhiNavigation { get; set; }
}
