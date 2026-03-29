using BHYTDashboard.Services.Interfaces;
using OfficeOpenXml;

namespace BHYTDashboard.Services
{
    public class ExportExcelService : IExportExcelService
    {
        public Task<byte[]> ExportBaoCaoThangAsync(int nam)
        {
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Thang");
            ws.Cells["A1"].Value = "Demo Export Thang";
            return Task.FromResult(package.GetAsByteArray());
        }

        public Task<byte[]> ExportBaoCaoNhomAsync(int nam)
        {
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Nhom");
            ws.Cells["A1"].Value = "Demo Export Nhom";
            return Task.FromResult(package.GetAsByteArray());
        }

        public Task<byte[]> ExportBaoCaoDoiTuongAsync(int nam)
        {
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("DoiTuong");
            ws.Cells["A1"].Value = "Demo Export DoiTuong";
            return Task.FromResult(package.GetAsByteArray());
        }

        public Task<byte[]> ExportTop10MaBenhAsync(int nam)
        {
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Top10");
            ws.Cells["A1"].Value = "Demo Export Top10";
            return Task.FromResult(package.GetAsByteArray());
        }
    }
}
