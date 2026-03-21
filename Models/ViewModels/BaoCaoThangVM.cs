namespace BHYTDashboard.Models.ViewModels
{
    /// <summary>
    /// ViewModel báo cáo chi phí BHYT theo tháng
    /// </summary>
    public class BaoCaoThangVM
    {
        /// <summary>Tháng (1-12)</summary>
        public int Thang { get; set; }

        /// <summary>Năm báo cáo</summary>
        public int Nam { get; set; }

        /// <summary>Tổng số hồ sơ trong tháng</summary>
        public int TongHoSo { get; set; }

        /// <summary>Tổng chi phí BHYT thanh toán (VNĐ)</summary>
        public decimal TongBHYTThanhToan { get; set; }

        /// <summary>Tổng chi phí bệnh nhân tự trả (VNĐ)</summary>
        public decimal TongBNTuTra { get; set; }

        /// <summary>Tỷ lệ tăng/giảm so với cùng kỳ năm trước (%)</summary>
        public double TyLeTangGiam { get; set; }
    }
}
