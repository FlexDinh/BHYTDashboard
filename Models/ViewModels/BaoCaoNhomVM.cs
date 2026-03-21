namespace BHYTDashboard.Models.ViewModels
{
    /// <summary>
    /// ViewModel báo cáo chi phí BHYT theo nhóm dịch vụ
    /// </summary>
    public class BaoCaoNhomVM
    {
        /// <summary>Mã nhóm dịch vụ</summary>
        public string MaNhom { get; set; } = string.Empty;

        /// <summary>Tên nhóm dịch vụ (VD: Khám bệnh, Xét nghiệm, PTTT...)</summary>
        public string TenNhom { get; set; } = string.Empty;

        /// <summary>Tổng chi phí của nhóm (VNĐ)</summary>
        public decimal TongChiPhi { get; set; }

        /// <summary>Tỷ lệ phần trăm so với tổng chi phí (%)</summary>
        public double TyLe { get; set; }
    }
}
