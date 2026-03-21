using BHYTDashboard.Models.ViewModels;

namespace BHYTDashboard.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        /// <summary>
        /// Lấy báo cáo chi phí BHYT theo từng tháng trong năm
        /// </summary>
        Task<List<BaoCaoThangVM>> GetBaoCaoTheoThangAsync(int nam);

        /// <summary>
        /// Lấy báo cáo chi phí BHYT theo nhóm dịch vụ
        /// </summary>
        Task<List<BaoCaoNhomVM>> GetBaoCaoTheoNhomAsync(int nam);

        /// <summary>
        /// Lấy báo cáo chi phí BHYT theo đối tượng khám chữa bệnh
        /// </summary>
        Task<List<BaoCaoDoiTuongVM>> GetBaoCaoTheoDoiTuongAsync(int nam);

        /// <summary>
        /// Lấy top 10 mã bệnh có số lượng hồ sơ nhiều nhất
        /// </summary>
        Task<List<Top10MaBenhVM>> GetTop10MaBenhAsync(int nam);

        /// <summary>
        /// Lấy dữ liệu KPI tổng hợp cho dashboard
        /// </summary>
        Task<KPICardVM> GetKPIDataAsync(int nam);
    }
}
