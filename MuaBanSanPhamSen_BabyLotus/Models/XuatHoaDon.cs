using System;

namespace MuaBanSanPhamSen_BabyLotus.Models
{
    public class XuatHoaDon
    {
        public int id { get; set; }     
        public string tenKhachHang { get; set; }    
        public string soDienThaoi { get; set; } 
        public int maSanPham { get; set; }  
        public string tenSanPham { get; set; } 
        public Decimal giaBan { get; set; } 
        public int soLuong { get; set; }    
        public Decimal tongTien { get; set; }   
        
        public DateTime ngayMua { get; set; }    
        public int maHoaDon { get; set; }   

        public string nhanVienLap { get; set; }     



    }
}
