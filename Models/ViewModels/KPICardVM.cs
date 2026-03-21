namespace BHYTDashboard.Models.ViewModels
{
    /// <summary>
    /// ViewModel hiển thị KPI tổng hợp trên dashboard
    /// Bao gồm dữ liệu năm hiện tại và năm trước để tính tỷ lệ tăng/giảm
    /// </summary>
    public class KPICardVM
    {
        // ===== DỮ LIỆU NĂM HIỆN TẠI =====

        /// <summary>Tổng số hồ sơ</summary>
        public int TongHoSo { get; set; }

        /// <summary>Tổng chi phí BHYT thanh toán (VNĐ)</summary>
        public decimal TongBHYTThanhToan { get; set; }

        /// <summary>Tổng chi phí bệnh nhân tự trả (VNĐ)</summary>
        public decimal TongBNTuTra { get; set; }

        /// <summary>Số ngày điều trị trung bình</summary>
        public double NgayDieuTriTrungBinh { get; set; }

        // ===== DỮ LIỆU NĂM TRƯỚC (để tính tỷ lệ tăng/giảm) =====

        /// <summary>Tổng số hồ sơ năm trước</summary>
        public int TongHoSoNamTruoc { get; set; }

        /// <summary>Tổng BHYT thanh toán năm trước (VNĐ)</summary>
        public decimal TongBHYTThanhToanNamTruoc { get; set; }

        /// <summary>Tổng BN tự trả năm trước (VNĐ)</summary>
        public decimal TongBNTuTraNamTruoc { get; set; }

        /// <summary>Ngày điều trị trung bình năm trước</summary>
        public double NgayDieuTriTrungBinhNamTruoc { get; set; }

        // ===== TỶ LỆ TĂNG/GIẢM (%) =====

        /// <summary>Tỷ lệ tăng/giảm hồ sơ so với năm trước</summary>
        public double TyLeTangGiamHoSo =>
            TongHoSoNamTruoc == 0 ? 0 :
            Math.Round((double)(TongHoSo - TongHoSoNamTruoc) / TongHoSoNamTruoc * 100, 2);

        /// <summary>Tỷ lệ tăng/giảm BHYT thanh toán so với năm trước</summary>
        public double TyLeTangGiamBHYT =>
            TongBHYTThanhToanNamTruoc == 0 ? 0 :
            Math.Round((double)(TongBHYTThanhToan - TongBHYTThanhToanNamTruoc) / (double)TongBHYTThanhToanNamTruoc * 100, 2);

        /// <summary>Tỷ lệ tăng/giảm BN tự trả so với năm trước</summary>
        public double TyLeTangGiamBNTuTra =>
            TongBNTuTraNamTruoc == 0 ? 0 :
            Math.Round((double)(TongBNTuTra - TongBNTuTraNamTruoc) / (double)TongBNTuTraNamTruoc * 100, 2);
    }
}
