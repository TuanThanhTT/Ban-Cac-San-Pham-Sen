using System;

namespace MuaBanSanPhamSen_BabyLotus.Models
{
    public class DonHangChoDuyet
    {
        public int id { get; set; }
        public int maHoaDonChiTiet { get; set; } 
        public int maDonHang { get; set; }

        public int maSanPham { get; set; }  
        public string tenSanPham { get; set; }
        public int soLuong { get; set; }
        public Decimal thanhTien { get; set; }
        public DateTime ngayTao { get; set; }
        public string trangThai { get; set; }   
    }
}
