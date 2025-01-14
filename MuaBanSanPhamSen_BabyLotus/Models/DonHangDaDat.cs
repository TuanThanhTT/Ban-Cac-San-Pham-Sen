using System;

namespace MuaBanSanPhamSen_BabyLotus.Models
{
    public class DonHangDaDat
    {
        public int Id { get; set; } 
        public int maDonHang { get; set; }  
        public int maSanPham { get; set; }  
        public string tenSanPham { get; set; }  
        public int soLuong { get; set; }    
        public Decimal gia { get; set; }    
        public Decimal tongTien { get; set; }
        public DateTime ngayDat { get; set; }
        public string trangThai { get; set; }   

    }
}
