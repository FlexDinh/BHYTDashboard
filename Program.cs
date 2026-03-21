using OfficeOpenXml;

// ===== KHỞI TẠO BUILDER =====
var builder = WebApplication.CreateBuilder(args);

// ===== CẤU HÌNH EPPlus (NonCommercial License) =====
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// ===== ĐĂNG KÝ SERVICES =====
builder.Services.AddControllersWithViews();

// ----- Entity Framework Core -----
// TODO (TV2): Bỏ comment khi đã tạo AppDbContext
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ----- Dependency Injection -----
// TODO (TV3): Bỏ comment khi đã tạo DashboardRepository
// builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

// TODO (TV3/TV5): Bỏ comment khi đã tạo DashboardService
// builder.Services.AddScoped<IDashboardService, DashboardService>();

// TODO (TV5): Bỏ comment khi đã tạo ExportExcelService
// builder.Services.AddScoped<IExportExcelService, ExportExcelService>();

// ===== BUILD APP =====
var app = builder.Build();

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

// ===== ROUTING — Mặc định trỏ đến Dashboard/Index =====
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
