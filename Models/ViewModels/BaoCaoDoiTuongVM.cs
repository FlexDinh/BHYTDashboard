namespace BHYTDashboard.Models.ViewModels
{
    /// <summary>
    /// ViewModel báo cáo chi phí BHYT theo đối tượng khám chữa bệnh
    /// </summary>
    public class BaoCaoDoiTuongVM
    {
        /// <summary>Mã đối tượng khám chữa bệnh</summary>
        public string MaDTKCB { get; set; } = string.Empty;

        /// <summary>Tên đối tượng (VD: Nội trú, Ngoại trú...)</summary>
        public string TenDoiTuong { get; set; } = string.Empty;

        /// <summary>Tổng số hồ sơ</summary>
        public int TongHoSo { get; set; }

        /// <summary>Tổng chi phí BHYT thanh toán (VNĐ)</summary>
        public decimal TongBHYTThanhToan { get; set; }

        /// <summary>Tỷ lệ phần trăm so với tổng (%)</summary>
        public double TyLe { get; set; }
    }
}
