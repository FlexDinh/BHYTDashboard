using Microsoft.AspNetCore.Mvc;
using BHYTDashboard.Services.Interfaces;
using BHYTDashboard.Models.ViewModels;

namespace BHYTDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IExportExcelService _exportExcelService;

        public DashboardController(
            IDashboardService dashboardService,
            IExportExcelService exportExcelService)
        {
            _dashboardService = dashboardService;
            _exportExcelService = exportExcelService;
        }

        /// <summary>
        /// Trang Dashboard chính — hiển thị KPI, biểu đồ, bảng dữ liệu
        /// </summary>
        /// <param name="nam">Năm hiển thị (mặc định = năm hiện tại)</param>
        [HttpGet]
        public async Task<IActionResult> Index(int? nam)
        {
            int namChon = nam ?? DateTime.Now.Year;
            var model = await _dashboardService.GetDashboardDataAsync(namChon);
            return View(model);
        }

        /// <summary>
        /// API trả về dữ liệu JSON cho Chart.js (gọi bằng AJAX)
        /// </summary>
        /// <param name="nam">Năm</param>
        /// <param name="loai">Loại biểu đồ: thang, nhom, doituong, top10benh</param>
        [HttpGet]
        public async Task<IActionResult> GetChartData(int nam, string loai)
        {
            try
            {
                var data = await _dashboardService.GetChartDataAsync(nam, loai);
                return Json(data);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// API trả toàn bộ dữ liệu dashboard theo năm (KPI + các báo cáo)
        /// Dùng cho AJAX reload không tải lại trang
        /// </summary>
        /// <param name="nam">Năm</param>
        [HttpGet]
        public async Task<IActionResult> GetDashboardData(int nam)
        {
            var data = await _dashboardService.GetDashboardDataAsync(nam);
            return Json(data);
        }

        /// <summary>
        /// Xuất dữ liệu ra file Excel (.xlsx)
        /// </summary>
        /// <param name="nam">Năm</param>
        /// <param name="loai">Loại báo cáo: thang, nhom, doituong, top10benh</param>
        [HttpGet]
        public async Task<IActionResult> ExportExcel(int nam, string loai)
        {
            byte[] fileBytes;
            string fileName;

            switch (loai?.ToLower())
            {
                case "thang":
                    fileBytes = await _exportExcelService.ExportBaoCaoThangAsync(nam);
                    fileName = $"BaoCao_TheoThang_{nam}.xlsx";
                    break;
                case "nhom":
                    fileBytes = await _exportExcelService.ExportBaoCaoNhomAsync(nam);
                    fileName = $"BaoCao_TheoNhom_{nam}.xlsx";
                    break;
                case "doituong":
                    fileBytes = await _exportExcelService.ExportBaoCaoDoiTuongAsync(nam);
                    fileName = $"BaoCao_TheoDoiTuong_{nam}.xlsx";
                    break;
                case "top10benh":
                    fileBytes = await _exportExcelService.ExportTop10MaBenhAsync(nam);
                    fileName = $"BaoCao_Top10MaBenh_{nam}.xlsx";
                    break;
                default:
                    return BadRequest(new { error = $"Loại báo cáo '{loai}' không hợp lệ." });
            }

            return File(
                fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
    }
}
