namespace BHYTDashboard.Models.ViewModels
{
    /// <summary>
    /// ViewModel top 10 mã bệnh có số lượng hồ sơ nhiều nhất
    /// </summary>
    public class Top10MaBenhVM
    {
        /// <summary>Mã bệnh ICD-10</summary>
        public string MaBenh { get; set; } = string.Empty;

        /// <summary>Tên bệnh</summary>
        public string TenBenh { get; set; } = string.Empty;

        /// <summary>Số lượng hồ sơ</summary>
        public int SoLuongHoSo { get; set; }

        /// <summary>Tỷ lệ phần trăm so với tổng hồ sơ (%)</summary>
        public double TyLe { get; set; }
    }
}
