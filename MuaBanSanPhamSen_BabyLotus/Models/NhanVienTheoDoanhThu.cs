using System;

namespace MuaBanSanPhamSen_BabyLotus.Models
{
    public class NhanVienTheoDoanhThu
    {
        public int maNhanVien { get; set; } 
        public string tenNhanVien { get; set; } 
        public Decimal doanhThu { get; set; }   
        public int soHoaDonLap { get; set; }    
    }
}
