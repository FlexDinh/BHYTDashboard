using BHYTDashboard.Models.ViewModels;

namespace BHYTDashboard.Services.Interfaces
{
    public interface IDashboardService
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu dashboard cho một năm cụ thể
        /// </summary>
        Task<DashboardViewModel> GetDashboardDataAsync(int nam);

        /// <summary>
        /// Lấy dữ liệu biểu đồ theo loại (thang, nhom, doituong, top10benh)
        /// Trả về object JSON-ready cho Chart.js
        /// </summary>
        Task<object> GetChartDataAsync(int nam, string loai);
    }
}
