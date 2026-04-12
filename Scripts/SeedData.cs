    using BHYTDashboard.Data;
    using BHYTDashboard.Models.Entities;
    using Bogus;

    namespace BHYTDashboard.Scripts
    {
        public class SeedData
        {
            public static void Initialize(BenhVienUbContext context)
            {
                if (context.HoSoBenhNhans.Any()) return;

                // ===== Danh mục =====
                var doiTuongs = new List<DanhMucDoiTuong>
                {
                    new() { MaDoiTuong = "DT1", TenDoiTuong = "BHYT" },
                    new() { MaDoiTuong = "DT2", TenDoiTuong = "Dịch vụ" },
                    new() { MaDoiTuong = "DT3", TenDoiTuong = "Miễn phí" }
                };

                var nhoms = new List<DanhMucNhomChiPhi>
                {
                    new() { MaNhomChiPhi = "N1", TenNhomChiPhi = "Thuốc" },
                    new() { MaNhomChiPhi = "N2", TenNhomChiPhi = "DVKT" },
                    new() { MaNhomChiPhi = "N3", TenNhomChiPhi = "Xét nghiệm" }
                };

                var icds = new List<DanhMucIcd10>
                {
                    new() { MaIcd = "A01", TenBenh = "Sốt thương hàn" },
                    new() { MaIcd = "B02", TenBenh = "Zona thần kinh" },
                    new() { MaIcd = "C03", TenBenh = "U ác tính" },
                    new() { MaIcd = "D04", TenBenh = "Ung thư da" }
                };

                context.AddRange(doiTuongs);
                context.AddRange(nhoms);
                context.AddRange(icds);
                context.SaveChanges();

                // ===== Hồ sơ bệnh nhân =====
                var hoSoFaker = new Faker<HoSoBenhNhan>()
                    .RuleFor(x => x.MaLk, f => Guid.NewGuid().ToString())
                    .RuleFor(x => x.MaBn, f => f.Random.Replace("BN###"))
                    .RuleFor(x => x.HoTen, f => f.Name.FullName())
                    .RuleFor(x => x.NgaySinh, f => f.Date.Past(30).Year)
                    .RuleFor(x => x.GioiTinh, f => f.Random.Int(0, 1))
                    .RuleFor(x => x.DiaChi, f => f.Address.FullAddress())
                    .RuleFor(x => x.MaTheBhyt, f => f.Random.Replace("BH#######"))
                    .RuleFor(x => x.MaDoiTuong, f => f.PickRandom(doiTuongs).MaDoiTuong)
                    .RuleFor(x => x.NgayVao, f => int.Parse(f.Date.Past(1).ToString("yyyyMMdd")))
                    .RuleFor(x => x.NgayRa, (f, x) => x.NgayVao + f.Random.Int(1, 10))
                    .RuleFor(x => x.ChanDoanVao, f => f.Lorem.Sentence())
                    .RuleFor(x => x.ChanDoanRa, f => f.Lorem.Sentence())
                    .RuleFor(x => x.MaBenhChinh, f => f.PickRandom(icds).MaIcd)
                    .RuleFor(x => x.MaKhoa, f => f.Random.Replace("K##"))
                    .RuleFor(x => x.TongChiPhi, f => f.Random.Int(100000, 5000000))
                    .RuleFor(x => x.TongBhchiTra, f => f.Random.Int(50000, 2000000))
                    .RuleFor(x => x.TongBenhNhanTra, f => f.Random.Int(50000, 2000000));

                var hoSoList = hoSoFaker.Generate(500);
                context.HoSoBenhNhans.AddRange(hoSoList);
                context.SaveChanges();

                // ===== Chi tiết thuốc =====
                var thuocFaker = new Faker<ChiTietThuoc>()
                    .RuleFor(x => x.MaLk, f => f.PickRandom(hoSoList).MaLk)
                    .RuleFor(x => x.MaThuoc, f => f.Random.Replace("T###"))
                    .RuleFor(x => x.TenThuoc, f => f.Commerce.ProductName())
                    .RuleFor(x => x.DonViTinh, f => "Viên")
                    .RuleFor(x => x.SoLuong, f => f.Random.Int(1, 10))
                    .RuleFor(x => x.DonGia, f => f.Random.Int(10000, 200000))
                    .RuleFor(x => x.ThanhTien, (f, x) => x.SoLuong * x.DonGia)
                    .RuleFor(x => x.TyLeThanhToan, f => f.Random.Int(50, 100))
                    .RuleFor(x => x.MaNhomChiPhi, f => "N1")
                    .RuleFor(x => x.MaKhoa, f => f.Random.Replace("K##"));

                context.ChiTietThuocs.AddRange(thuocFaker.Generate(1000));

                // ===== Chi tiết DVKT =====
                var dvktFaker = new Faker<ChiTietDvkt>()
                    .RuleFor(x => x.MaLk, f => f.PickRandom(hoSoList).MaLk)
                    .RuleFor(x => x.MaDichVu, f => f.Random.Replace("DV###"))
                    .RuleFor(x => x.TenDichVu, f => f.Commerce.ProductName())
                    .RuleFor(x => x.SoLuong, f => f.Random.Int(1, 5))
                    .RuleFor(x => x.DonGia, f => f.Random.Int(50000, 500000))
                    .RuleFor(x => x.ThanhTien, (f, x) => x.SoLuong * x.DonGia)
                    .RuleFor(x => x.MaNhomChiPhi, f => f.PickRandom(new[] { "N2", "N3" }))
                    .RuleFor(x => x.MaKhoa, f => f.Random.Replace("K##"))
                    .RuleFor(x => x.MaBacSi, f => f.Random.Replace("BS##"))
                    .RuleFor(x => x.NgayYlenh, f => int.Parse(f.Date.Recent().ToString("yyyyMMdd")))
                    .RuleFor(x => x.NgayKetQua, f => int.Parse(f.Date.Recent().ToString("yyyyMMdd")));

                context.ChiTietDvkts.AddRange(dvktFaker.Generate(1000));

                context.SaveChanges();
            }
        }
    }