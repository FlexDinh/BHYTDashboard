using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHYTDashboard.Migrations
{
    /// <inheritdoc />
    public partial class BHYTDashBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucDoiTuong",
                columns: table => new
                {
                    MaDoiTuong = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenDoiTuong = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DanhMucD__291408A164B5DC2E", x => x.MaDoiTuong);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucICD10",
                columns: table => new
                {
                    MaICD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenBenh = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DanhMucI__3B5EE75567E3A4FA", x => x.MaICD);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNhomChiPhi",
                columns: table => new
                {
                    MaNhomChiPhi = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenNhomChiPhi = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DanhMucN__40482F3C9128A357", x => x.MaNhomChiPhi);
                });

            migrationBuilder.CreateTable(
                name: "HoSoBenhNhan",
                columns: table => new
                {
                    MaLK = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MaBN = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HoTen = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NgaySinh = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    MaTheBHYT = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaDoiTuong = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NgayVao = table.Column<int>(type: "int", nullable: false),
                    NgayRa = table.Column<int>(type: "int", nullable: false),
                    ChanDoanVao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ChanDoanRa = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    MaBenhChinh = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaCSKCB = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TongChiPhi = table.Column<int>(type: "int", nullable: true),
                    TongBHChiTra = table.Column<int>(type: "int", nullable: true),
                    TongBenhNhanTra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoSoBenh__2725C77A7CB7A511", x => x.MaLK);
                    table.ForeignKey(
                        name: "FK__HoSoBenhN__MaBen__440B1D61",
                        column: x => x.MaBenhChinh,
                        principalTable: "DanhMucICD10",
                        principalColumn: "MaICD");
                    table.ForeignKey(
                        name: "FK__HoSoBenhN__MaDoi__4316F928",
                        column: x => x.MaDoiTuong,
                        principalTable: "DanhMucDoiTuong",
                        principalColumn: "MaDoiTuong");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDVKT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLK = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MaDichVu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TenDichVu = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    MaVatTu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TenVatTu = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<int>(type: "int", nullable: true),
                    ThanhTien = table.Column<int>(type: "int", nullable: true),
                    MaNhomChiPhi = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaBacSi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NgayYLenh = table.Column<int>(type: "int", nullable: true),
                    NgayKetQua = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietD__3214EC07508B6BB4", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ChiTietDVK__MaLK__3C69FB99",
                        column: x => x.MaLK,
                        principalTable: "HoSoBenhNhan",
                        principalColumn: "MaLK");
                    table.ForeignKey(
                        name: "FK__ChiTietDV__MaNho__45F365D3",
                        column: x => x.MaNhomChiPhi,
                        principalTable: "DanhMucNhomChiPhi",
                        principalColumn: "MaNhomChiPhi");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietThuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLK = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MaThuoc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TenThuoc = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DonViTinh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<int>(type: "int", nullable: true),
                    ThanhTien = table.Column<int>(type: "int", nullable: true),
                    TyLeThanhToan = table.Column<int>(type: "int", nullable: true),
                    MaNhomChiPhi = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaKhoa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietT__3214EC076F5A254A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ChiTietTh__MaNho__44FF419A",
                        column: x => x.MaNhomChiPhi,
                        principalTable: "DanhMucNhomChiPhi",
                        principalColumn: "MaNhomChiPhi");
                    table.ForeignKey(
                        name: "FK__ChiTietThu__MaLK__398D8EEE",
                        column: x => x.MaLK,
                        principalTable: "HoSoBenhNhan",
                        principalColumn: "MaLK");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDVKT_MaLK",
                table: "ChiTietDVKT",
                column: "MaLK");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDVKT_MaNhomChiPhi",
                table: "ChiTietDVKT",
                column: "MaNhomChiPhi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThuoc_MaLK",
                table: "ChiTietThuoc",
                column: "MaLK");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThuoc_MaNhomChiPhi",
                table: "ChiTietThuoc",
                column: "MaNhomChiPhi");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoBenhNhan_MaBenhChinh",
                table: "HoSoBenhNhan",
                column: "MaBenhChinh");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoBenhNhan_MaDoiTuong",
                table: "HoSoBenhNhan",
                column: "MaDoiTuong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDVKT");

            migrationBuilder.DropTable(
                name: "ChiTietThuoc");

            migrationBuilder.DropTable(
                name: "DanhMucNhomChiPhi");

            migrationBuilder.DropTable(
                name: "HoSoBenhNhan");

            migrationBuilder.DropTable(
                name: "DanhMucICD10");

            migrationBuilder.DropTable(
                name: "DanhMucDoiTuong");
        }
    }
}
