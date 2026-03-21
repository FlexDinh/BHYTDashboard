# 📊 BHYT Dashboard — Hệ thống Dashboard Bảo Hiểm Y Tế

Dashboard quản lý và thống kê chi phí Bảo Hiểm Y Tế (BHYT) được xây dựng trên nền tảng **ASP.NET Core MVC**.

## 🛠️ Công nghệ sử dụng

- **Backend:** ASP.NET Core MVC (.NET 9)
- **Database:** SQL Server (Entity Framework Core)
- **Charts:** Chart.js (AJAX)
- **Export Excel:** EPPlus
- **Seed Data:** Bogus

## 📁 Cấu trúc thư mục

```
BHYTDashboard/
├── Controllers/
│   └── DashboardController.cs          ← (TV1 - Khang)
├── Models/
│   ├── Entities/                       ← (TV2)
│   └── ViewModels/                     ← (TV1 - Khang)
├── Data/
│   └── AppDbContext.cs                 ← (TV2)
├── Repositories/
│   ├── Interfaces/                     ← (TV1 - Khang)
│   └── DashboardRepository.cs          ← (TV3)
├── Services/
│   ├── Interfaces/                     ← (TV1 - Khang)
│   ├── DashboardService.cs             ← (TV3)
│   └── ExportExcelService.cs           ← (TV5)
├── Views/
│   └── Dashboard/Index.cshtml          ← (TV4)
├── wwwroot/
│   ├── css/                            ← (TV4)
│   └── js/                             ← (TV4)
├── Program.cs                          ← (TV1 - Khang)
└── appsettings.json                    ← (TV1 - Khang)
```

## 👥 Phân công nhóm

| Thành viên | Vai trò | File phụ trách |
|---|---|---|
| **TV1 - Đinh Hoàng Minh Khang** | Controller + Tích hợp + Điều phối | `DashboardController.cs`, `ViewModels/*.cs`, `Interfaces/*.cs`, `Program.cs`, `appsettings.json` |
| **TV2** | Database + Entity + DbContext | `Models/Entities/*.cs`, `Data/AppDbContext.cs`, Migrations, Seed Data |
| **TV3** | Repository + Service Layer | `DashboardRepository.cs`, `DashboardService.cs` |
| **TV4** | Frontend (View + JS + CSS) | `Views/Dashboard/*.cshtml`, `wwwroot/js/*.js`, `wwwroot/css/*.css` |
| **TV5** | Export Excel Service | `Services/ExportExcelService.cs` |

## 🚀 Cách chạy

```bash
# Restore packages
dotnet restore

# Build
dotnet build

# Chạy development server
dotnet run

# Truy cập: https://localhost:5001 hoặc http://localhost:5000
```

## 📌 Hướng dẫn Git cho từng thành viên

```bash
# Clone repo
git clone <URL_REPO>
cd BHYTDashboard

# Tạo branch riêng
git checkout -b feature/ten-ban

# Sau khi code xong
git add .
git commit -m "Mô tả thay đổi"
git push origin feature/ten-ban

# Tạo Pull Request trên GitHub để merge vào dev
```

## 📋 Quy tắc

1. **Không push trực tiếp vào `main` hoặc `dev`** — luôn tạo Pull Request
2. **Mỗi người làm trên branch riêng** (`feature/ten-ban`)
3. **Trước khi push**, đảm bảo `dotnet build` pass
4. **Code review** bởi TV1 trước khi merge
