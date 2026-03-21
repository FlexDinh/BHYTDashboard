namespace BHYTDashboard.Models.ViewModels
{
    /// <summary>
    /// ViewModel tổng hợp cho trang Dashboard
    /// Chứa toàn bộ dữ liệu cần hiển thị trên trang chính
    /// </summary>
    public class DashboardViewModel
    {
        /// <summary>Năm đang được chọn hiển thị</summary>
        public int Nam { get; set; }

        /// <summary>Danh sách các năm có dữ liệu (dùng cho dropdown)</summary>
        public List<int> DanhSachNam { get; set; } = new List<int>();

        /// <summary>Dữ liệu KPI tổng hợp</summary>
        public KPICardVM KPI { get; set; } = new KPICardVM();

        /// <summary>Báo cáo chi phí theo từng tháng</summary>
        public List<BaoCaoThangVM> BaoCaoTheoThang { get; set; } = new List<BaoCaoThangVM>();

        /// <summary>Báo cáo chi phí theo nhóm dịch vụ</summary>
        public List<BaoCaoNhomVM> BaoCaoTheoNhom { get; set; } = new List<BaoCaoNhomVM>();

        /// <summary>Báo cáo chi phí theo đối tượng KCB</summary>
        public List<BaoCaoDoiTuongVM> BaoCaoTheoDoiTuong { get; set; } = new List<BaoCaoDoiTuongVM>();

        /// <summary>Top 10 mã bệnh có nhiều hồ sơ nhất</summary>
        public List<Top10MaBenhVM> Top10MaBenh { get; set; } = new List<Top10MaBenhVM>();
    }
}
