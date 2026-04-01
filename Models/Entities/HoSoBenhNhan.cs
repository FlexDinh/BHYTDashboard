using System;
using System.Collections.Generic;

namespace BHYTDashboard.Models.Entities;

public partial class HoSoBenhNhan
{
    public string MaLk { get; set; } = null!;

    public string MaBn { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public int NgaySinh { get; set; }

    public int GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? MaTheBhyt { get; set; }

    public string? MaDoiTuong { get; set; }

    public int NgayVao { get; set; }

    public int NgayRa { get; set; }

    public string? ChanDoanVao { get; set; }

    public string? ChanDoanRa { get; set; }

    public string? MaBenhChinh { get; set; }

    public string? MaCskcb { get; set; }

    public string? MaKhoa { get; set; }

    public int? TongChiPhi { get; set; }

    public int? TongBhchiTra { get; set; }

    public int? TongBenhNhanTra { get; set; }

    public virtual ICollection<ChiTietDvkt> ChiTietDvkts { get; set; } = new List<ChiTietDvkt>();

    public virtual ICollection<ChiTietThuoc> ChiTietThuocs { get; set; } = new List<ChiTietThuoc>();

    public virtual DanhMucIcd10? MaBenhChinhNavigation { get; set; }

    public virtual DanhMucDoiTuong? MaDoiTuongNavigation { get; set; }
}
