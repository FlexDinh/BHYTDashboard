using BHYTDashboard.Models.ViewModels;
using BHYTDashboard.Repositories.Interfaces;
using BHYTDashboard.Services.Interfaces;

namespace BHYTDashboard.Services
{
        public class DashboardService : IDashboardService
        {
            private readonly IDashboardRepository _repo;

            public DashboardService(IDashboardRepository repo)
            {
                _repo = repo;
            }

            public async Task<DashboardViewModel> GetDashboardDataAsync(int nam)
            {
                var danhSachNam = await _repo.GetDanhSachNamAsync();
                
                return new DashboardViewModel
                {
                    Nam = nam,
                    DanhSachNam = danhSachNam,
                    BaoCaoTheoThang = await _repo.GetBaoCaoTheoThangAsync(nam),
                    BaoCaoTheoNhom = await _repo.GetBaoCaoTheoNhomAsync(nam),
                    BaoCaoTheoDoiTuong = await _repo.GetBaoCaoTheoDoiTuongAsync(nam),
                    Top10MaBenh = await _repo.GetTop10MaBenhAsync(nam),
                    KPI = await _repo.GetKPIDataAsync(nam)
                };
            }

            public async Task<object> GetChartDataAsync(int nam, string loai)
            {
                switch (loai)
                {
                    case "thang":
                        return await _repo.GetBaoCaoTheoThangAsync(nam);
                    case "nhom":
                        return await _repo.GetBaoCaoTheoNhomAsync(nam);
                    case "doituong":
                        return await _repo.GetBaoCaoTheoDoiTuongAsync(nam);
                    case "top10benh":
                        return await _repo.GetTop10MaBenhAsync(nam);
                    default:
                        return null;
                }
            }
        }
}
