using BHYTDashboard.Data;
using BHYTDashboard.Repositories;
using BHYTDashboard.Repositories.Interfaces;
using BHYTDashboard.Scripts;
using BHYTDashboard.Services;
using BHYTDashboard.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

// ===== KHỞI TẠO BUILDER =====
var builder = WebApplication.CreateBuilder(args);

// ===== CẤU HÌNH EPPlus (NonCommercial License) =====
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// ===== ĐĂNG KÝ SERVICES =====
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IExportExcelService, ExportExcelService>();
// ----- Entity Framework Core -----
// TODO (TV2): Bỏ comment khi đã tạo AppDbContext
builder.Services.AddDbContext<BenhVienUbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// ===== BUILD APP =====
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BenhVienUbContext>();
    SeedData.Initialize(context);
}
// ===== MIDDLEWARE PIPELINE =====
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

// ===== ROUTING — Mặc định trỏ đến Home/Index (Landing Page) =====
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
