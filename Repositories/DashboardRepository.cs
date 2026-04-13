using BHYTDashboard.Data;
using BHYTDashboard.Models.ViewModels;
using BHYTDashboard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BHYTDashboard.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly BenhVienUbContext _context;

        public DashboardRepository(BenhVienUbContext context)
        {
            _context = context;
        }

        // ================== BÁO CÁO THEO THÁNG ==================
        public async Task<List<BaoCaoThangVM>> GetBaoCaoTheoThangAsync(int nam)
        {
            var data = await _context.HoSoBenhNhans
                .Where(x => x.NgayVao / 10000 == nam)
                .GroupBy(x => x.NgayVao / 100 % 100)
                .Select(g => new BaoCaoThangVM
                {
                    Thang = g.Key,
                    Nam = nam,
                    TongHoSo = g.Count(),
                    TongBHYTThanhToan = g.Sum(x => x.TongBhchiTra ?? 0),
                    TongBNTuTra = g.Sum(x => x.TongBenhNhanTra ?? 0)
                })
                .OrderBy(x => x.Thang)
                .ToListAsync();

            // 👉 Tính tăng giảm so với năm trước
            var dataNamTruoc = await _context.HoSoBenhNhans
                .Where(x => x.NgayVao / 10000 == nam - 1)
                .GroupBy(x => x.NgayVao / 100 % 100)
                .Select(g => new
                {
                    Thang = g.Key,
                    Tong = g.Sum(x => x.TongBhchiTra)
                })
                .ToListAsync();

            foreach (var item in data)
            {
                var truoc = dataNamTruoc.FirstOrDefault(x => x.Thang == item.Thang);
                if (truoc != null && truoc.Tong != 0)
                {
                    item.TyLeTangGiam = Math.Round(
                        (double)(item.TongBHYTThanhToan - truoc.Tong) / (double)truoc.Tong * 100, 2);
                }
            }

            return data;
        }

        // ================== THEO NHÓM ==================
        public async Task<List<BaoCaoNhomVM>> GetBaoCaoTheoNhomAsync(int nam)
        {
            var query = await _context.ChiTietDvkts
                .Where(x => x.NgayYlenh / 10000 == nam)
                .GroupBy(x => x.MaNhomChiPhi)
                .Select(g => new
                {
                    MaNhom = g.Key,
                    Tong = g.Sum(x => x.ThanhTien)
                })
                .ToListAsync();

            var total = query.Sum(x => x.Tong);

            var result = (from q in query
                          join n in _context.DanhMucNhomChiPhis
                          on q.MaNhom equals n.MaNhomChiPhi
                          select new BaoCaoNhomVM
                          {
                              MaNhom = q.MaNhom,
                              TenNhom = n.TenNhomChiPhi,
                              TongChiPhi = (decimal)(q.Tong ?? 0),
                              TyLe = total == 0 ? 0 : Math.Round((double)q.Tong / (double)total * 100, 2)
                          }).ToList();

            return result;
        }

        // ================== THEO ĐỐI TƯỢNG ==================
        public async Task<List<BaoCaoDoiTuongVM>> GetBaoCaoTheoDoiTuongAsync(int nam)
        {
            var query = await _context.HoSoBenhNhans
                .Where(x => x.NgayVao / 10000 == nam)
                .GroupBy(x => x.MaDoiTuong)
                .Select(g => new
                {
                    Ma = g.Key,
                    TongHoSo = g.Count(),
                    TongTien = g.Sum(x => x.TongBhchiTra)
                })
                .ToListAsync();

            var total = query.Sum(x => x.TongTien);

            var result = (from q in query
                          join d in _context.DanhMucDoiTuongs
                          on q.Ma equals d.MaDoiTuong
                          select new BaoCaoDoiTuongVM
                          {
                              MaDTKCB = q.Ma,
                              TenDoiTuong = d.TenDoiTuong,
                              TongHoSo = q.TongHoSo,
                              TongBHYTThanhToan = (decimal)(q.TongTien ?? 0),
                              TyLe = total == 0 ? 0 : Math.Round((double)q.TongTien / (double)total * 100, 2)
                          }).ToList();

            return result;
        }

        // ================== TOP 10 BỆNH ==================
        public async Task<List<Top10MaBenhVM>> GetTop10MaBenhAsync(int nam)
        {
            var query = await _context.HoSoBenhNhans
                .Where(x => x.NgayVao / 10000 == nam)
                .GroupBy(x => x.MaBenhChinh)
                .Select(g => new
                {
                    MaBenh = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToListAsync();

            var total = query.Sum(x => x.Count);

            var result = (from q in query
                          join i in _context.DanhMucIcd10s
                          on q.MaBenh equals i.MaIcd
                          select new Top10MaBenhVM
                          {
                              MaBenh = q.MaBenh,
                              TenBenh = i.TenBenh,
                              SoLuongHoSo = q.Count,
                              TyLe = total == 0 ? 0 : Math.Round((double)q.Count / total * 100, 2)
                          }).ToList();

            return result;
        }

        // ================== KPI ==================
        public async Task<KPICardVM> GetKPIDataAsync(int nam)
        {
            var current = await _context.HoSoBenhNhans
                .Where(x => x.NgayVao / 10000 == nam)
                .ToListAsync();

            var prev = await _context.HoSoBenhNhans
                .Where(x => x.NgayVao / 10000 == nam - 1)
                .ToListAsync();

            return new KPICardVM
            {
                // năm hiện tại
                TongHoSo = current.Count,
                TongBHYTThanhToan = current.Sum(x => x.TongBhchiTra ?? 0),
                TongBNTuTra = current.Sum(x => x.TongBenhNhanTra ?? 0),
                NgayDieuTriTrungBinh = current.Count == 0 ? 0 :
                    current.Average(x => (x.NgayRa - x.NgayVao)),

                // năm trước
                TongHoSoNamTruoc = prev.Count,
                TongBHYTThanhToanNamTruoc = prev.Sum(x => x.TongBhchiTra ?? 0),
                TongBNTuTraNamTruoc = prev.Sum(x => x.TongBenhNhanTra ?? 0),
                NgayDieuTriTrungBinhNamTruoc = prev.Count == 0 ? 0 :
                    prev.Average(x => (x.NgayRa - x.NgayVao))
            };
        }

        // ================== DANH SÁCH NĂM ==================
        public async Task<List<int>> GetDanhSachNamAsync()
        {
            var danhSachNam = await _context.HoSoBenhNhans
                .Where(x => x.NgayVao != 0)
                .Select(x => x.NgayVao / 10000)
                .Distinct()
                .OrderByDescending(x => x)
                .ToListAsync();

            return danhSachNam;
        }
    }
}