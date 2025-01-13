using System;

namespace MuaBanSanPhamSen_BabyLotus.Models
{
    public class ThongTinDonHangDuyet
    { 
        public int ID { get; set; } 
        public int maKhachHang { get; set; }    
        public string tenKhachHang { get; set; }    
        public int maDonHang { get; set; }  
        public DateTime ngayDatHang { get; set; }   
        public Decimal tongTien { get; set; }   

    }
}
