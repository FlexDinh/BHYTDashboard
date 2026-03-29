using BHYTDashboard.Repositories.Interfaces;
using BHYTDashboard.Models.ViewModels;

namespace BHYTDashboard.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        public Task<List<BaoCaoThangVM>> GetBaoCaoTheoThangAsync(int nam)
        {
            return Task.FromResult(new List<BaoCaoThangVM>());
        }

        public Task<List<BaoCaoNhomVM>> GetBaoCaoTheoNhomAsync(int nam)
        {
            return Task.FromResult(new List<BaoCaoNhomVM>());
        }

        public Task<List<BaoCaoDoiTuongVM>> GetBaoCaoTheoDoiTuongAsync(int nam)
        {
            return Task.FromResult(new List<BaoCaoDoiTuongVM>());
        }

        public Task<List<Top10MaBenhVM>> GetTop10MaBenhAsync(int nam)
        {
            return Task.FromResult(new List<Top10MaBenhVM>());
        }

        public Task<KPICardVM> GetKPIDataAsync(int nam)
        {
            return Task.FromResult(new KPICardVM());
        }
    }
}
