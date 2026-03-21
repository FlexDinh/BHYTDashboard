namespace BHYTDashboard.Services.Interfaces
{
    public interface IExportExcelService
    {
        /// <summary>
        /// Xuất báo cáo chi phí BHYT theo tháng ra file Excel
        /// </summary>
        Task<byte[]> ExportBaoCaoThangAsync(int nam);

        /// <summary>
        /// Xuất báo cáo chi phí BHYT theo nhóm dịch vụ ra file Excel
        /// </summary>
        Task<byte[]> ExportBaoCaoNhomAsync(int nam);

        /// <summary>
        /// Xuất báo cáo chi phí BHYT theo đối tượng KCB ra file Excel
        /// </summary>
        Task<byte[]> ExportBaoCaoDoiTuongAsync(int nam);

        /// <summary>
        /// Xuất top 10 mã bệnh ra file Excel
        /// </summary>
        Task<byte[]> ExportTop10MaBenhAsync(int nam);
    }
}
