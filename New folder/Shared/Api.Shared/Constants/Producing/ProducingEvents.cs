using System;

namespace Vino.Shared.Constants.Producing
{
    public static class ProducingEvents
    {
        [Display("Chuẩn bị đất")] public const string ChuanBiDat = "ChuanBiDat";
        [Display("Xuống giống")] public const string XuongGiong = "XuongGiong";
        [Display("Chăm sóc cây con")] public const string ChamSocCayCon = "ChamSocCayCon";
        [Display("Khử lẫn bố")] public const string KhuLanBo = "KhuLanBo";
        [Display("Khử lưỡng tính")] public const string KhuLuongTinh = "KhuLuongTinh";
        [Display("Thụ phấn")] public const string ThuPhan = "ThuPhan";
        [Display("Hủy cây bố")] public const string HuyCayBo = "HuyCayBo";
        [Display("Chăm sóc cây")] public const string ChamSocCay = "ChamSocCay";
        [Display("Lập kế hoạch thu hoạch")] public const string LapKeHoachThuHoach = "LapKeHoachThuHoach";
        [Display("Lập kế hoạch thu mua")] public const string LapKeHoachThuMua = "LapKeHoachThuMua";
        [Display("Khử lẫn cây mẹ")] public const string KhuLanCayMe = "KhuLanCayMe";
        [Display("Thu trái bổ trái")] public const string ThuTraiBoTrai = "ThuTraiBoTrai";
        [Display("Phơi hạt")] public const string PhoiHat = "PhoiHat";
        [Display("Bảo quản")] public const string BaoQuan = "BaoQuan";
        [Display("Lấy mẫu test IEF")] public const string LayMauTestIef = "LayMauTestIef";
        [Display("Thu mua")] public const string ThuMua = "ThuMua";
        [Display("Trồng hậu kiểm")] public const string TrongHauKiem = "TrongHauKiem";
        [Display("Thanh toán hậu kiểm")] public const string ThanhToanHauKiem = "ThanhToanHauKiem";
    }

    [AttributeUsage(AttributeTargets.All)]
    public class DisplayAttribute : Attribute
    {
        public DisplayAttribute(){}

        public DisplayAttribute(string display)
        {
            Display = display;
        }
        public string Display { get; set; }
    }
}